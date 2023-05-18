namespace TravelBooks.Identity.Data;

/// <summary>
/// DbContext application
/// </summary>
public class TravelBooksIdentityContext : DbContext
{

    public TravelBooksIdentityContext(DbContextOptions<TravelBooksIdentityContext> options) : base(options) { }

    /// <summary>
    /// Identity applaction users
    /// </summary>
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
