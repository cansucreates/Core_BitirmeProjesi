using Core_BitirmeProjesi.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_BitirmeProjesi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<User> Users { get; set; }  
    }
}
