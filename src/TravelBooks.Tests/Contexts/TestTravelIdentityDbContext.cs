namespace TravelBooks.Tests.Contexts
{
    public class TestTravelIdentityDbContext : TravelBooksIdentityContext
    {
        public TestTravelIdentityDbContext(DbContextOptions<TravelBooksIdentityContext> options) : base(options)
        {
        }
    }
}

