using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace TravelBooks.Core.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Editorial> Editorials { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AuthorsBooks>()
       .HasKey(bc => new { bc.BookId, bc.AuthorId });
            builder.Entity<AuthorsBooks>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.AuthorsBooks)
                .HasForeignKey(bc => bc.BookId);
            builder.Entity<AuthorsBooks>()
                .HasOne(bc => bc.Author)
                .WithMany(c => c.AuthorsBooks)
                .HasForeignKey(bc => bc.AuthorId);
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}