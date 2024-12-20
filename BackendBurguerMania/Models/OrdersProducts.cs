using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BackendBurguerMania.Models
{
    public class OrdersProducts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_OrdersProducts { get; set; }

        [ForeignKey("Product")]
        public int Product_ID { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Order")]
        public int Order_ID { get; set;}
        public Order Order { get; set; }
        
    }
}