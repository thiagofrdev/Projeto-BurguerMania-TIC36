using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BackendBurguerMania.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int ID_Category { get; set; }

        [Required]
        [StringLength(100)]
        public string Name_Category { get; set; }

        [Required]
        [StringLength(100)]
        public string Description_Category { get; set; }

        [Required]
        [StringLength(100)]
        public string Path_Image_Category { get; set; }
    }
}