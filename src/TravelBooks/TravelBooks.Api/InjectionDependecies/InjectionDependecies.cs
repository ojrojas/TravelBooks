using System.Text;
using Core.Interfaces;
using Core.Services.Authors;
using Core.Services.Books;
using Core.Services.Editorials;
using Core.Services.Identity;
using Core.Services.Login;
using Infraestructure.AppContext;
using Infraestructure.Data;
using Infraestructure.Identity;
using Infraestructure.Logger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Api.InjectionDependencies
{
    public static class AddServices
    {

        public static IServiceCollection AddServiceDbContextInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(c =>
                c.UseSqlServer(configuration.GetConnectionString("MillionAndUpConnection")));
            return services;
        }


        public static IServiceCollection AddServiceInjection(this IServiceCollection services)
        {
            services.AddScoped<IAsyncIdentityRepository, AsyncIdentityRepository>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
            services.AddScoped(typeof(IAppLogger<>), typeof(AppLoggerAdapter<>));
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ITokenClaims, IdentityClaims>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IEditorialService, EditorialService>();


            return services;
        }

        public static IServiceCollection AddJwtServices(this IServiceCollection services, IConfiguration configuration)
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

        public static IServiceCollection AddJwtOptionAuthentication(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
          {
              c.SwaggerDoc("v1", new OpenApiInfo { Title = "MillonAndUp", Version = "v1" });
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
}
