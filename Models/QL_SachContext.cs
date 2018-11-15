using Microsoft.EntityFrameworkCore;

namespace Demo_Services.Models
{
    public class QL_SachContext : DbContext
    {
         public QL_SachContext(DbContextOptions<QL_SachContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Book> Books { get; set; }
    }
}