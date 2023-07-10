using System.ComponentModel.DataAnnotations;

namespace Core1.Models
{
    public class LanguageModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string? Name { get; set; }

        public ICollection<BookModel> Books { get; set; }
    }
}
