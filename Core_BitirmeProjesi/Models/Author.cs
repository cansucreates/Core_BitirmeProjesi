﻿using System.ComponentModel.DataAnnotations;

namespace Core_BitirmeProjesi.Models
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string Name { get; set; }
        public string Biography { get; set; }
        public virtual List<Book> Books { get; set; } = new List<Book>();
    }
}
