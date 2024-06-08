using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core_BitirmeProjesi.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string Title { get; set; }
        [Required, Range(0,2024, ErrorMessage = "Yıl 0-2024 arasında olmalıdır")]
        public int PublishedDate { get; set; }
        [ForeignKey("Author")]
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }
    }
}
