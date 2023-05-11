using Microsoft.EntityFrameworkCore;

namespace DemoRepositoryPattern.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }


        #region DbSet
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        #endregion
    }
}
