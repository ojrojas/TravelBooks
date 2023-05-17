namespace TravelBooks.Core.Repositories;

public class EditorialRepository : AsyncRepository<Editorial>
{
    public EditorialRepository(ILogger<AsyncRepository<Editorial>> logger, DbContext context) : base(logger, context)
    {
    }
}

