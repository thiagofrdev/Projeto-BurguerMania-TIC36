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
    [Route("api/[controller]")]
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
            var users = await _context.Products.ToListAsync();
            if (users is null)
            {
                return NotFound("Nenhum usuário encontrado");
            }
            return Ok($"{users.Count} usuários encontados:" + users);
        }

        //Rota para adicioanr todos os Usuários
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Users>>> AddNewUser(Users user)
        {
            if (await UserExistsAsync(user))
            {
                return BadRequest("Já existe um usuário com esse Email");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("Usuário cadastrado om sucesso!" + user);
        }

        //Método para verificar se um usuário existe, comparando id e email
        private async Task<bool> UserExistsAsync(Users user)
        {
            return await _context.Users.AnyAsync(u => u.Email_User == user.Email_User);
        }

        //Função para criar o hash do password
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        //Função para verificar o hash do password
        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}