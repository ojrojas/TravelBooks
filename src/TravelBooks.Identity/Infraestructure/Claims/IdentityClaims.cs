using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Constants;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace TravelBooks.Identity.Infraestructure;

public class IdentityClaims : ITokenClaims
{
    private readonly IAsyncIdentityRepository _userContext;
    private readonly IConfiguration _configuration;

    public IdentityClaims(
        IAsyncIdentityRepository userContext,
        IConfiguration configuration)
    {
        _userContext = userContext;
        _configuration = configuration;
    }

    public async Task<string> GetTokenAsync(string userName, string Password)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["JwtOptions:SecretKey"]);
        var specificationUser = new ApplicationUserSpecification(userName, Password);
        var user = await _userContext.FindApplicationUser(specificationUser);
        var claims = new List<Claim>();

        if (user != null)
        {
            foreach (PropertyInfo prop in user.GetType().GetProperties())
            {
                var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                if (prop.Name != "DecryptedPassword")
                    if (prop.GetValue(user, null) != null)
                        claims.Add(new Claim(prop.Name, prop.GetValue(user, null).ToString()));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            await Task.CompletedTask;
            return tokenHandler.WriteToken(token);
        }

        await Task.CompletedTask;
        return null;
    }
}
