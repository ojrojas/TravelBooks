namespace TravelBooks.Identity.Infraestructure;

public class IdentityRepository : AsyncRepository<ApplicationUser>, IAsyncRepository<ApplicationUser>
{
    /// <summary>
    /// Repository application user
    /// </summary>
    public IdentityRepository(ILogger<AsyncRepository<ApplicationUser>> logger, TravelBooksIdentityContext context, ISpecificationEvaluator specificationEvaluator) : base(logger, context, specificationEvaluator)
    {
    }
}
