namespace TravelBooks.Identity.Data;

public class TravelBooksIdentityContext : DbContext
{
    public TravelBooksIdentityContext(DbContextOptions<TravelBooksIdentityContext> options) : base(options) { }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
}
