namespace TravelBooks.Identity.DI;

/// <summary>
/// Helper context application
/// </summary>
public static class ContextApplicationDI
{
    /// <summary>
    /// Add context application
    /// </summary>
    /// <param name="services">Service collection application</param>
    /// <param name="configuration">Configuration application</param>
    /// <returns>Services registers</returns>
    public static IServiceCollection AddContextApplicationDI(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TravelBooksIdentityContext>(
            ctx => ctx.UseSqlite(
                configuration.GetConnectionString("connectionIdentity")));
        return services;
    }
}

