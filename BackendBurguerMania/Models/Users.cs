using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendBurguerMania.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_User { get; set; }

        [Required]
        [StringLength(100)]
        public string Name_User { get; set; }

        [Required]
        [StringLength(150)]
        [EmailAddress] //Garante que o e-mail tenha o formato correto
        public string Email_User { get; set; }

        [Required]
        public string Password_Hash { get; set; }
    }
}