namespace TravelBooks.Identity.Services;

public class TokenService<T> : ITokenService<T>
{
    private readonly ILogger<TokenService<T>> _logger;
    private readonly OptionToken _options;

    public TokenService(ILogger<TokenService<T>> logger, IOptions<OptionToken> options)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _options = options.Value ?? throw new ArgumentNullException(nameof(options));
    }

    /// <summary>
    /// Get Token jwt
    /// </summary>
    /// <param name="user">User login application</param>
    /// <returns>jwt string token</returns>
    public async Task<string> GetTokenAsync(T user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_options.SecretPhrase);
        var claims = new List<Claim>();

        foreach (PropertyInfo prop in user.GetType().GetProperties())
        {
            _ = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
            if (prop.Name != "Password")
                if (prop.GetValue(user, null) != null)
                    claims.Add(new Claim(prop.Name, prop.GetValue(user, null).ToString()));
        }

        await Task.CompletedTask;

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims.ToArray()),
            Expires = DateTime.UtcNow.AddHours(12),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}