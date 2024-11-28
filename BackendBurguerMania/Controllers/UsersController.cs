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
            if (await UserExistsAsync(user))
            {
                return BadRequest("Já existe um usuário com esse Email");
            }

            user.Password_Hash = PasswordService.HashPassword(user.Password_Hash);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Usuário cadastrado com sucesso!", User = user });
        }

        //Método para verificar se um usuário existe, comparando id e email
        private async Task<bool> UserExistsAsync(Users user)
        {
            return await _context.Users.AnyAsync(u => u.Email_User == user.Email_User);
        }
    }
}