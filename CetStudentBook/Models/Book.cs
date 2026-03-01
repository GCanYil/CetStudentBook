using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CetStudentBook.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; } //Integer , Primary Key, Auto-increment
        
        [Required]
        [Length(2,200)]
        public string Name { get; set; }
        
        [Required]
        [Length(2,200)]
        public string Author { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayName("Publish Date")]
        public DateTime PublishDate { get; set; }
        
        [Required]
        [Range(1,10000)]
        [DisplayName("Page Count")]
        public int PageCount { get; set; }
        
        [Required]
        [DisplayName("Tick If Second Hand")]
        public bool IsSecondHand { get; set; }
        
        

    }
}