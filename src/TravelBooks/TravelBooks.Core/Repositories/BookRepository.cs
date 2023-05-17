namespace TravelBooks.Core.Repositories;

public class BookRepository : AsyncRepository<Book>
{
    public BookRepository(ILogger<AsyncRepository<Book>> logger, DbContext context) : base(logger, context)
    {
    }
}

