using System.ComponentModel.DataAnnotations;

namespace Core_BitirmeProjesi.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string? Password { get; set; }
    }
}
