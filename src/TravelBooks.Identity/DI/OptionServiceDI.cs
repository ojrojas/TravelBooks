namespace TravelBooks.Identity.DI;

/// <summary>
/// Option Service Injection
/// </summary>
public static class OptionServiceDI
{
    /// <summary>
    /// Add option configuration application
    /// </summary>
    /// <param name="services">Service collection application</param>
    /// <param name="configuration">Configuration application</param>
    /// <returns>Service regiters</returns>
	public static IServiceCollection AddOptionServiceDI(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<OptionEncrypt>(configuration.GetSection("OptionEncrypt"));
        services.Configure<OptionToken>(configuration.GetSection("Jwt"));
        return services;
    }
}

