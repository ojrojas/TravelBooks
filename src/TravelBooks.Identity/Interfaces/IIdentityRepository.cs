namespace TravelBooks.Identity.Interfaces;

public interface IIdentityRepository
{
    Task<ApplicationUser> CreateApplicationUser(ApplicationUser entity, CancellationToken cancellationToken);
    Task<ApplicationUser> DeleteApplicationUser(ApplicationUser entity, CancellationToken cancellationToken);
    Task<ApplicationUser> FindApplicationUser(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<ApplicationUser>> GetAllAsync(CancellationToken cancellationToken);
    Task<ApplicationUser> LoginAppUser(ApplicationUser entity, CancellationToken cancellationToken);
    Task<ApplicationUser> UpdateApplicationUser(ApplicationUser entity, CancellationToken cancellationToken);
}