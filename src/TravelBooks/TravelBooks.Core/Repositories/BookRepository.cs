namespace TravelBooks.Core.Repositories;

public class BookRepository : AsyncRepository<Book>
{
    public BookRepository(ILogger<AsyncRepository<Book>> logger, TravelBooksDbContext context) : base(logger, context)
    {
    }
}

