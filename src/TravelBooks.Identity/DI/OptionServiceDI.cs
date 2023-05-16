namespace TravelBooks.Identity.DI;

public static class OptionServiceDI
{
	public static IServiceCollection AddOptionServiceDI(this IServiceCollection services, IConfiguration configuration)
	{
            services.Configure<OptionEncrypt>(configuration.GetSection("OptionEncrypt"));
            services.Configure<OptionToken>(configuration.GetSection("Jwt"));
            return services;
    }
}

