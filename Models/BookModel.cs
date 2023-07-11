using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Core1.Data;

using System.ComponentModel.DataAnnotations.Schema;

namespace Core1.Models
{
    public class BookModel 
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the title of your book")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Please enter the author name")]
        public string? Author { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        public string? Category { get; set; }
        [Required]
        [DisplayName("Language")]
        public int LanguageId { get; set; }

        [Required(ErrorMessage = "Please enter the total pages")]
        [DisplayName("Total pages of book")]
        public int? TotalPages { get; set; }

        public Languages? Language { get; set; }

        [DisplayName("Book Cover")]
        public IFormFile? Cover { get; set; }
        public string? CoverUrl { get; set; }

    }
}
