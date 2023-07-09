using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core1.Models
{
    public class Item
    {
        [Key]
        [Required]
        public int ProductId { get; set; }

        [Required(ErrorMessage ="You Should Insert Item Name")]
        [StringLength(99)]
        public string Name { get; set; }

        [Required]
        [Range(10, 99000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public double Price { get; set; }


        [Required]
        public int Quantity { get; set; }
        public DateTime CreatedAT { get; set; } = DateTime.Now;

        [Required]
        [DisplayName("Category")]
        [ForeignKey("Category")]
        public int CategotyId { get; set; } 

        public Category? Category { get; set; }  
    }
}
