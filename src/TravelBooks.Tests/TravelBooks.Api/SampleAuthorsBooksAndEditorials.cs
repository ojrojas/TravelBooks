using TravelBooks.Core.Entities;

namespace TravelBooks.Tests.TravelBooks.Api;
internal static class SampleAuthorsBooksAndEditorials
{
    public static IEnumerable<Author> GetSampleAuthors() =>
        new List<Author>
        {
                new Author
                {
                    Name = "SachaTest",
                    LastName ="SechaTest",
                    CreatedBy = Guid.NewGuid(),
                    CreatedOn = DateTime.UtcNow,
                    State = true,
                },
                new Author
                {
                    Name = "TeslaTest",
                    LastName ="ToslaTest",
                    CreatedBy = Guid.NewGuid(),
                    CreatedOn = DateTime.UtcNow,
                    State = true,
                },
                new Author
                {
                    Name = "ToretoTest",
                    LastName ="TataretoTest",
                    CreatedBy = Guid.NewGuid(),
                    CreatedOn = DateTime.UtcNow,
                    State = true,
                },
        };

    public static IEnumerable<Book> GetSampleBooks() =>
        new List<Book>
        {
                new Book
                {
                    Pages = 1_000,
                    Sipnosis = "TestSipnosis",
                    Title = "TestBook1",
                },
                new Book
                {
                    Pages = 800,
                    Sipnosis = "TestSipnosis",
                    Title = "TestBook2",
                },
                new Book
                {
                    Pages = 350,
                    Sipnosis = "TestSipnosis",
                    Title = "TestBook3",
                }
        };


    public static IEnumerable<Editorial> GetSampleEditorial() =>
        new List<Editorial>
        {
                new Editorial
                {
                    Name = "Test1",
                    Sede = "TestSede1"
                },
                new Editorial
                {
                    Name = "Test2",
                    Sede = "TestSede2"
                },
        };
}
