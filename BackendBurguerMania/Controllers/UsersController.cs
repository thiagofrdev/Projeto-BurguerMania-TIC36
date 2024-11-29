using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using BackendBurguerMania.Context;
using BackendBurguerMania.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendBurguerMania.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BurguerManiaContext _context;

        //Construtor
        public UsersController(BurguerManiaContext context)
        {
            _context = context;
        }

        //Rota para todos os Usuários
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            if (!users.Any())
            {
                return NotFound("Nenhum usuário encontrado");
            }
            return Ok(new{ Message = $"{users.Count} usuários encontrados.", Users = users });
        }

        //Rota para adicioanr todos os Usuários
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Users>>> AddNewUser(Users user)
        {
            //Verifica se o campo de email está vazio ou se o email é valido usando a função IsValidEmail()
            if (string.IsNullOrEmpty(user.Email_User) || !IsValidEmail(user.Email_User))
            {
                return BadRequest("E-mail invalido");
            }

            if (string.IsNullOrEmpty(user.Password_Hash) || user.Password_Hash.Length < 8)
            {
                return BadRequest("A senha deve ter pelo menos 8 caracteres");
            }

            //Verifica se já existe um usuário com o email inserido
            if (await UserExistsAsync(user))
            {
                return BadRequest("Já existe um usuário com esse Email");
            }

            user.Password_Hash = PasswordService.HashPassword(user.Password_Hash);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Usuário cadastrado com sucesso!", User = user });
        }

        //Rota para editar um usuário (pegando pelo email)
        [HttpPut("{email}")]
        public async Task<ActionResult<IEnumerable<Users>>> EditUserByEmail(Users user, string email)
        {
            if (!await UserExistsAsync(email))
            {
                return NotFound($"Não foi encontrado um usuário com o email {email}");
            }

            user.Password_Hash = PasswordService.HashPassword(user.Password_Hash);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Ok(new { Message= "Usuário alterado com sucesso!", User = user });
        }

        [HttpDelete("{email}")]
        public async Task<ActionResult<IEnumerable<Users>>> DeleteUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email_User == email);

            if (user is null)
                return NotFound($"Não foi encontrado um usuário com o email {email}");

            string nameUser = user.Name_User;
            string emailUser = user.Email_User;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok($"O usuário {nameUser} ({emailUser}) foi removido com sucesso");
        }

        //Método para verificar se um usuário existe
        private async Task<bool> UserExistsAsync(Users user)
        {
            return await _context.Users.AnyAsync(u => u.Email_User == user.Email_User);
        }

        private async Task<bool> UserExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(user => user.Email_User == email);
        }

        private bool IsValidEmail(string email){
            if (string.IsNullOrEmpty(email))
            {return false;}

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch { return false;}
        }
    }
}