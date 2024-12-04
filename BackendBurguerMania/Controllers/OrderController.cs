using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BackendBurguerMania.Context;
using BackendBurguerMania.Models;
using BackendBurguerMania.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BackendBurguerMania.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly BurguerManiaContext _context;

        public OrderController(BurguerManiaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            if (!orders.Any())
            {
                return NotFound("Não foi encontrada nenhuma categoria");
            }

            return Ok(new { Message = $"{orders.Count} categorias encontradas", Orders = orders });
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderDto orderDto)
        {
            //Validação
            if (orderDto == null || orderDto.Products.Count == 0)
                return BadRequest("O pedido deve conter pelo menos um produto.");

            //Criando o pedido
            var order = new Order
            {
                Value_Order = orderDto.Value_Order,
                Status_ID = orderDto.Status_ID
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            //Relacionando o pedido aos produtos
            foreach (var product in orderDto.Products)
            {
                var orderProduct = new OrdersProducts
                {
                    Order_ID = order.ID_Order,
                    Product_ID = product.Product_ID,
                };
                _context.OrdersProducts.Add(orderProduct);
            }

            // Relacionar o pedido ao usuário
            var userOrder = new UsersOrders
            {
                Order_ID = order.ID_Order,
                User_ID = orderDto.User_ID
            };
            _context.UsersOrders.Add(userOrder);

            await _context.SaveChangesAsync();

            return Ok(new { message = "Pedido criado com sucesso!", order });
        }
    }
}