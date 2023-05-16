namespace TravelBooks.Identity.Interfaces;

public interface IIdentityService
{
    Task<ApplicationUser> FindApplicationUser(Guid Id);
    Task<ApplicationUser> CreateApplicationUser(ApplicationUser eniy);
    Task<ApplicationUser> UpdateApplicationUser(ApplicationUser entity);
    Task<ApplicationUser> DeleteApplicationUser(Guid Id);
    Task<ApplicationUser> LoginAppUser(ApplicationUser entity);
    Task<IReadOnlyList<ApplicationUser>> GetAllAsync();
}