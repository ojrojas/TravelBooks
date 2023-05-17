namespace TravelBooks.Identity.DI;

public static class ServiceApplicationDI
{
	public static IServiceCollection AddServiceApplicationDI(this IServiceCollection services)
	{
		services.AddTransient(typeof(IdentityRepository));
		services.AddTransient(typeof(ITokenService<>), typeof(TokenService<>));
		services.AddTransient<IEncryptService, EncryptService>();
		services.AddTransient<IApplicationUserService, ApplicationUserService>();
		return services;
	}
}

