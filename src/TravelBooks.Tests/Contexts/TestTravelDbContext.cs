namespace TravelBooks.Tests.Contexts;

public class TestTravelDbContext : TravelBooksDbContext
{
    public TestTravelDbContext(DbContextOptions<TravelBooksDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=:memory:");
        base.OnConfiguring(optionsBuilder);
    }
}

