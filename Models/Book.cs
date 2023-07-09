using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using System.ComponentModel.DataAnnotations.Schema;

namespace Core1.Models
{
    public class Book 
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
        public string? Language { get; set; }

        [Required(ErrorMessage = "Please enter the total pages")]
        [DisplayName("Total pages of book")]
        public int? TotalPages { get; set; }

    }
}
