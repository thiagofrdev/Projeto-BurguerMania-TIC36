using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendBurguerMania.Models
{
    public class OrdersProducts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID_OrdersProducts { get; set; }

        [ForeignKey("Product")]
        public int Product_ID { get; set; }

        [ForeignKey("Order")]
        public int Order_ID { get; set;}
    }
}