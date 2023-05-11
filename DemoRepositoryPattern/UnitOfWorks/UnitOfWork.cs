using DemoRepositoryPattern.Data;
using DemoRepositoryPattern.Interfaces;
using DemoRepositoryPattern.Repositories;

namespace DemoRepositoryPattern.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IBookRepository Books { get; private set; }
        public IAuthorRepository Authors { get; private set; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Books = new BookRepository(_context);
            Authors = new AuthorRepository(_context);
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
