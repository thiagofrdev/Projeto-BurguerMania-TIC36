using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BackendBurguerMania.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Order { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Value_Order { get; set; }

        [ForeignKey("Status")]
        public int Status_ID { get; set; }
        public Status Status { get; set; }

        public ICollection<OrdersProducts> OrdersProducts { get; set; }
        public ICollection<UsersOrders> UsersOrders { get; set; }
    }
}