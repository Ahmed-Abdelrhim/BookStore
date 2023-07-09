using System.ComponentModel.DataAnnotations;
namespace Core1.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; } 

        public ICollection<Item>? Items { get; set; }
    }
}
