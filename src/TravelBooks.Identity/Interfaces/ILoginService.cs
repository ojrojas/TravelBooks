namespace TravelBooks.Identity.Interfaces;

public interface ILoginService
{
    Task<string> Login(ApplicationUser user);
}