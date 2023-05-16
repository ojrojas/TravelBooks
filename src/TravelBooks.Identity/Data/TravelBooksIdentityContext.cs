namespace TravelBooks.Identity.Data;

public class TravelBooksIdentityContext : DbContext
{
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
}
