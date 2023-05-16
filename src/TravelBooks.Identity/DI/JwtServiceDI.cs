namespace TravelBooks.Identity.DI;

public static class JwtServiceDI
{
	public static IServiceCollection AddJwtServiceDI(this IServiceCollection services, IConfiguration configuration)
	{
        var key = Encoding.ASCII.GetBytes(configuration["JwtOptions:SecretKey"]);
        services.AddAuthentication(config =>
        {
            config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(config =>
        {
            config.RequireHttpsMetadata = false;
            config.SaveToken = true;
            config.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        return services;
    }
}

