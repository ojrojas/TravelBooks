namespace TravelBooks.Core.Repositories;

public class AuthorRepository : AsyncRepository<Author>
{
    public AuthorRepository(ILogger<AsyncRepository<Author>> logger, DbContext context) : base(logger, context)
    {
    }
}

