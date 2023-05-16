namespace TravelBooks.Identity.Services;

public interface IEncryptService
{
    Task<string> Encrypt(string password, bool useHashing = true);
}