using DemoRepositoryPattern.Data;
using DemoRepositoryPattern.Interfaces;

namespace DemoRepositoryPattern.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
