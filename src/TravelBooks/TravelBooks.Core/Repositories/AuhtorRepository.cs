namespace TravelBooks.Core.Repositories;

public class AuthorRepository : AsyncRepository<Author>
{
    public AuthorRepository(ILogger<AsyncRepository<Author>> logger, TravelBooksDbContext context) : base(logger, context)
    {
    }
}

