namespace TravelBooks.Identity.DI;

public static class ServiceApplicationDI
{
	public static IServiceCollection AddServiceApplicationDI(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddTransient(typeof(IdentityRepository));
		services.AddTransient<IApplicationUserService, ApplicationUserService>();
		services.AddTransient<IEncryptService, EncryptService>();
		services.AddTransient(typeof(ITokenService<>), typeof(TokenService<>));
		return services;
	}
}

