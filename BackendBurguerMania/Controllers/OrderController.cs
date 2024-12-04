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
        public async Task<ActionResult> GetAllOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.Status) // Carrega o Status relacionado
                .Include(o => o.OrdersProducts) // Carrega os produtos relacionados
                    .ThenInclude(op => op.Product) // Inclui os detalhes dos produtos
                .Include(o => o.UsersOrders) // Carrega os usuários relacionados
                    .ThenInclude(uo => uo.User) // Inclui os detalhes do usuário
                .ToListAsync();

            if (!orders.Any())
            {
                return NotFound("Não foi encontrada nenhum pedido");
            }

            // Projeção dos dados para o retorno
            var ordersWithDetails = orders.Select(o => new
            {
                o.ID_Order,
                o.Value_Order,
                Status = new
                {
                    o.Status.ID_Status,
                    o.Status.Name_Status
                },
                Products = o.OrdersProducts.Select(op => new
                {
                    op.Product_ID,
                    op.Product.Name_Product, // Assumindo que existe um campo Name_Product no model Product
                    op.Product.Price_Product
                }),
                User = o.UsersOrders.Select(uo => new
                {
                    uo.User_ID,
                    uo.User.Name_User, // Assumindo que existe um campo Name_User no model User
                    uo.User.Email_User
                }).FirstOrDefault() // Um pedido normalmente é associado a um único usuário
            }).ToList();

            return Ok(new { Message = $"{orders.Count} pedidos encontrados", Orders = ordersWithDetails });
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderDto orderDto)
        {
            //Validação
            if (orderDto == null || orderDto.Products.Count == 0)
                return BadRequest("O pedido deve conter pelo menos um produto.");
            
            // Garantindo que o pedido comece com o status "Pedido feito"
            var statusInicial = await _context.Statuses.FirstOrDefaultAsync(s => s.Name_Status == "Pedido feito");
            if (statusInicial == null)
                return BadRequest("Status inicial não encontrado no sistema.");

            //Criando o pedido
            var order = new Order
            {
                Value_Order = orderDto.Value_Order,
                Status_ID = statusInicial.ID_Status
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

            return Ok(new
            {
                message = "Pedido criado com sucesso!",
                order = new
                {
                    order.ID_Order,
                    order.Value_Order,
                    Status = new
                    {
                        statusInicial.ID_Status,
                        statusInicial.Name_Status
                    }
                }
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound(new { message = "Status não encontrado." });
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}