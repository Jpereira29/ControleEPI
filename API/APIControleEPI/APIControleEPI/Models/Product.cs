using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIControleEPI.Models
{
    public class Product
    {
        [Key]
        public int ProdutId { get; set; }

        [Required]
        [MaxLength(80)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(300)]
        public string? ImageUrl { get; set; }
        public DateTime DateRegister { get; set; }

        public int CategoryId { get; set; }

        [JsonIgnore]
        public Category? Category { get; set; }
    }
}
