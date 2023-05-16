namespace TravelBooks.Identity.Interfaces;

public interface ITokenClaims 
{
    Task<string> GetTokenAsync(string userName, string Password);
}