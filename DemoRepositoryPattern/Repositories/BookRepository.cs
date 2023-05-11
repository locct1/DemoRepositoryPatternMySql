using DemoRepositoryPattern.Data;
using DemoRepositoryPattern.Interfaces;

namespace DemoRepositoryPattern.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }
    }
}
