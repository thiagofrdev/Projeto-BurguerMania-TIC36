using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendBurguerMania.Models;
using BackendBurguerMania.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendBurguerMania.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly BurguerManiaContext _context;

        public ProductController(BurguerManiaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _context.Products.Include(p => p.Categories).ToListAsync();

            if (!products.Any())
                return BadRequest("Nenhum Produto encontrado");

            return Ok(new {Message = $"Foram encontrados {products.Count()} produtos.", Products = products});
        }

        [HttpGet("{nome}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByName(string productName)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Name_Product == productName);

            if (product == null)
                return BadRequest($"Produto '{productName}' não encontrado");
            
            return Ok(new { Message = $"{productName} encontrado", Products = product});
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Product>>> AddProduct(Product product)
        {
            if (await ProductExists(product.Name_Product))
                return BadRequest($"Já existe um product com o nome '{product.Name_Product}'");

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(new {Message = $"Produto {product.Name_Product} criado com sucesso", Products = product});
        }

        [HttpPut("{name}")]
        public async Task<ActionResult<IEnumerable<Product>>> EditProductByName([FromBody] Product product, string name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await ProductExists(name))
                return BadRequest($"Produto '{name}' não encontrado");

            product.Name_Product = product.Name_Product;
            product.Path_Image_Product = product.Path_Image_Product;
            product.Price_Product = product.Price_Product;
            product.Base_Description_Product = product.Base_Description_Product;
            product.Full_Description_Product = product.Full_Description_Product;
            product.Category_ID = product.Category_ID;
            
            product.Categories = await _context.Categories.FirstOrDefaultAsync(c => c.ID_Category == product.Category_ID);

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return Ok(new { Message = $"{name} atualizado com sucesso", Product = product });
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult<IEnumerable<Product>>> DeleteProductByName(string name)
        {
            if (!await ProductExists(name))
                return BadRequest($"Produto '{name}' não encontrado");
            
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Name_Product == name);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(new { Message = $"{name} removido com sucesso", Product = product });
        }

        private async Task<bool> ProductExists (string productName)
        {
            return await _context.Products.AnyAsync(p => p.Name_Product == productName);
        }
    }
}