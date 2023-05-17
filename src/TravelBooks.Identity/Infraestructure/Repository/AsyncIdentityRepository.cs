namespace TravelBooks.Identity.Infraestructure;

public class IdentityRepository : AsyncRepository<ApplicationUser>
{
    /// <summary>
    /// Repository application user
    /// </summary>
    public IdentityRepository(
        ILogger<AsyncRepository<ApplicationUser>> logger,
        TravelBooksIdentityContext context) : base(logger, context)
    {
    }
}
