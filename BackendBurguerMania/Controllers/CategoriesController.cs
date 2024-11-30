using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BackendBurguerMania.Context;
using Microsoft.AspNetCore.Mvc;
using BackendBurguerMania.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendBurguerMania.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly BurguerManiaContext _context;

        public CategoriesController(BurguerManiaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            if (!categories.Any())
            {
                return NotFound("Não foi encontrada nenhuma categoria");
            }

            return Ok(new { Message = $"{categories.Count} categorias encontradas", Categories = categories });
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoryByName(string name)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name_Category.Equals(name));
            if (category is null)
                return NotFound($"Categoria '{name}' não encontrada");

            return Ok(new { Message = $"Categoria {name} encontrada", Category = category });
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoryByID(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.ID_Category == id);

            if (category is null)
                return BadRequest("Categoria não encontrada");

            return Ok(category.Name_Category);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Category>>> AddCategory([FromBody] Category category)
        {
            if (string.IsNullOrEmpty(category.Name_Category))
                return BadRequest("O nome não pode estar vazio");
            
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Categoria criada com sucesso", Category = category});
        }

        [HttpPut("{name}")]
        public async Task<ActionResult<IEnumerable<Category>>> EditCategoryByName([FromBody] Category category, string name)
        {
            if (_context.Categories.FirstOrDefaultAsync(c => c.Name_Category == name) is null)
                return BadRequest($"Categoria {name} não encontrada");

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return Ok(new {Message = $"Categoria {name} atualizada com sucesso", Category = category});
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult<IEnumerable<Category>>> DeleteCategoryByName(string name)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name_Category == name); 

            if (category is null)
                return BadRequest($"Categoria {name} não encontrada");

            _context.Categories.Remove(category);
            _context.SaveChangesAsync();

            return Ok($"Categoria {name} removida com sucesso");
        }
    }
}