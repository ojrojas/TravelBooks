namespace TravelBooks.Identity.Services;

/// <summary>
/// Encrypt password services
/// </summary>
public interface IEncryptService
{
    /// <summary>
    /// Encrypt string password one way 
    /// </summary>
    /// <param name="password">Password string</param>
    /// <param name="useHashing">use hashing parameter</param>
    /// <returns>Encrypted password</returns>
    Task<string> Encrypt(string password, bool useHashing = true);
}