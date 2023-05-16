namespace TravelBooks.Identity.Interfaces;

public interface ITokenService<T>
{
    Task<string> GetTokenAsync(T user);
}