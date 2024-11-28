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
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly BurguerManiaContext _context;

        public ProductController(BurguerManiaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = product.ID_Product }, product);
        }
    }
}