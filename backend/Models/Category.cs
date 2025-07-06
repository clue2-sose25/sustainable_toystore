using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        // Navigation property
        public List<Toy> Toys { get; set; } = new List<Toy>();
    }
}