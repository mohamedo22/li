using Library_DEMO.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_DEMO.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<IdentityCard> IdentityCards { get; set; }
    }
}
