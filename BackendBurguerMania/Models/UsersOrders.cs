using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendBurguerMania.Models
{
    public class UsersOrders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_UserOrders { get; set; }

        [ForeignKey("Users")]
        public int User_ID { get; set; }

        [ForeignKey("Order")]
        public int Order_ID { get; set;}
    }
}