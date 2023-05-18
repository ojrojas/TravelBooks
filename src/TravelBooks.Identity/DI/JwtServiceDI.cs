namespace TravelBooks.Identity.DI;

/// <summary>
/// JwtService Injection
/// </summary>
public static class JwtServiceDI
{
    /// <summary>
    /// Add Jwt service
    /// </summary>
    /// <param name="services">Service collection application</param>
    /// <param name="configuration">Configuration application</param>
    /// <returns>Service registers</returns>
	public static IServiceCollection AddJwtServiceDI(this IServiceCollection services, IConfiguration configuration)
    {
        var key = Encoding.ASCII.GetBytes(configuration["Jwt:SecretPhrase"]);
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

