namespace TravelBooks.Core.Contexts
{
	public class TravelBooksDbContext : DbContext
	{
		public TravelBooksDbContext(DbContextOptions<TravelBooksDbContext> options): base(options)
		{
		}

		public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Editorial> Editorials { get; set; }
	}
}

