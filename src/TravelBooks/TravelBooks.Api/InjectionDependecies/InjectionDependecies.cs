namespace TravelBooks.Api.InjectionDependencies;

public static class AddServices
{
    public static IServiceCollection AddServiceDbContextInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TravelBooksDbContext>(c =>
        {
            c.UseSqlite(configuration.GetConnectionString("travelconnection"));
            c.EnableSensitiveDataLogging();
        });
        return services;
    }


    public static IServiceCollection AddServiceInjection(this IServiceCollection services)
    {
        services.AddTransient(typeof(EditorialRepository));
        services.AddTransient(typeof(AuthorRepository));
        services.AddTransient(typeof(BookRepository));
        services.AddTransient<IAuthorService, AuthorService>();
        services.AddTransient<IBookService, BookService>();
        services.AddTransient<IEditorialService, EditorialService>();


        return services;
    }

    public static IServiceCollection AddJwtServices(this IServiceCollection services, IConfiguration configuration)
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

    public static IServiceCollection AddSwaggerAuthentication(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
      {
          c.SwaggerDoc("v1", new OpenApiInfo { Title = "TravelBooks", Version = "v1" });
          c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
          {
              Name = "Authorization",
              Type = SecuritySchemeType.ApiKey,
              Scheme = "Bearer",
              BearerFormat = "JWT",
              In = ParameterLocation.Header,
              Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
          });
          c.AddSecurityRequirement(new OpenApiSecurityRequirement
          {
                {
                      new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                }
          });
      });

        return services;
    }
}
