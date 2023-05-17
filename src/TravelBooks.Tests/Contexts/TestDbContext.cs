using Microsoft.EntityFrameworkCore;

namespace TravelBooks.Tests.Contexts;

public class TestDbContext : DbContext
	{
		public TestDbContext(DbContextOptions<TestDbContext> options): base(options)
		{
		}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=:memory:");
        base.OnConfiguring(optionsBuilder);
    }
}

