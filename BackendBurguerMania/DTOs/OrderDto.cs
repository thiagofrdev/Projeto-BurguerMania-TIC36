using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendBurguerMania.DTOs
{
    public class OrderDto
    {
        // Valor total do pedido
        public decimal Value_Order { get; set; }

        // ID do status (ex.: "pendente" ou "concluído")
        public int Status_ID { get; set; } = 1; // Padrão: pendente

        // ID do usuário que fez o pedido
        public int User_ID { get; set; }

        // Lista de produtos incluídos no pedido
        public List<OrderProductDto> Products { get; set; }
    }
}