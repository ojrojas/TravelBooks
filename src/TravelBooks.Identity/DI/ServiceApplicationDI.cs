namespace TravelBooks.Identity.DI;

/// <summary>
/// Service application injection repositories, services
/// </summary>
public static class ServiceApplicationDI
{
    /// <summary>
    /// Add Services instances application
    /// </summary>
    /// <param name="services">Service collection application</param>
    /// <param name="configuration">Configuration application</param>
    /// <returns>Service regiters</returns>
    public static IServiceCollection AddServiceApplicationDI(this IServiceCollection services)
    {
        services.AddTransient(typeof(IdentityRepository));
        services.AddTransient(typeof(ITokenService<>), typeof(TokenService<>));
        services.AddTransient<IEncryptService, EncryptService>();
        services.AddTransient<IApplicationUserService, ApplicationUserService>();
        return services;
    }
}

