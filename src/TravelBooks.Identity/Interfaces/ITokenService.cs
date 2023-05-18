namespace TravelBooks.Identity.Interfaces;

/// <summary>
/// Token service 
/// </summary>
/// <typeparam name="T">Type entity to tokenized</typeparam>
public interface ITokenService<T>
{
    /// <summary>
    /// Get token of T parameter entity
    /// </summary>
    /// <param name="user">Entity to tokenized application</param>
    /// <returns></returns>
    Task<string> GetTokenAsync(T user);
}