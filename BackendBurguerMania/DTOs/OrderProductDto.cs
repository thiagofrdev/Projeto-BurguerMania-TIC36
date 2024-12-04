using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendBurguerMania.DTOs
{
    public class OrderProductDto
    {
        // ID do produto
        public int Product_ID { get; set; }

        // Quantidade do produto no pedido
        public int Quantity { get; set; }
    }
}