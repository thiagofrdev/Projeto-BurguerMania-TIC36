using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackendBurguerMania.Models
{
    public class Product
    {
        [Key] //Define como Chave Primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Define como Auto-increment
        public int ID_Product { get; set; }

        [Required] //Define que é NOT NULL
        [StringLength(100)] //Limita o tamanho do campo no banco
        public string Name_Product { get; set; }

        [Required]
        public string Path_Image_Product { get; set; }

        [Required] //Define que é NOT NULL
        [Column(TypeName = "decimal(10, 2)")] //Especifica como o número será armazrnado no banco
        public decimal Price_Product { get; set; }

        [Required]
        [StringLength(300)]
        public string Base_Description_Product { get; set; }

        [Required]
        [StringLength(1500)]
        public string Full_Description_Product { get; set; }

        [ForeignKey("Categories")]
        public int Category_ID { get; set;}

        [JsonIgnore]
        public Category? Categories { get; set; }

        [NotMapped]
        [JsonPropertyName("CategoryName")]
        public string? CategoryName => Categories?.Name_Category;
    }
}