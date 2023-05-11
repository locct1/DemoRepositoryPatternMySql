namespace DemoRepositoryPattern.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }
        IAuthorRepository Authors { get; }
        int Save();
    }
}
