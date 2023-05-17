namespace TravelBooks.Identity.DI;

public static class ContextApplicationDI
{
	public static IServiceCollection AddContextApplicationDI(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<TravelBooksIdentityContext>(
			ctx => ctx.UseSqlite(
				configuration.GetConnectionString("connectionIdentity")));
		return services;
	}
}

