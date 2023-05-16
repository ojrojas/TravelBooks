namespace TravelBooks.Identity.Entities;

/// <summary>
/// Model Application User
/// </summary>
public class ApplicationUser : BaseEntity, IAggregateRoot
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
}