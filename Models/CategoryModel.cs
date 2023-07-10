using System.ComponentModel.DataAnnotations;
namespace Core1.Models
{
    public class CategoryModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; } 

        public ICollection<ItemModel>? Items { get; set; }
    }
}
