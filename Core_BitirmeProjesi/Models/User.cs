using System.ComponentModel.DataAnnotations;

namespace Core_BitirmeProjesi.Models
{
    public class User
    {
        [Key]
        public required int UserId { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public required string Username { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public required string? Password { get; set; }
    }
}
