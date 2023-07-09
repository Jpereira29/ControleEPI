using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace APIControleEPI.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(80)]
        public string? Name { get; set; }

        public ICollection<Product> Products { get; set; } = new Collection<Product>();
    }
}
