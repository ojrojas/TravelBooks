namespace TravelBooks.Tests.TravelBooks.Api;
public class AuthorShould
{
    private AuthorsController _controller;

    [Fact]
    public async Task AuthorShould_CreateAuthor()
    {
        await SetController();
        CreateAuthorRequest request = new CreateAuthorRequest
        {
            Author = new Author
            {
                Name = "Tercero",
                LastName = "Tercio",
                CreatedBy = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,
                State = true,
            },
        };

        CreateAuthorResponse response = await _controller.CreateAsync(request, CancellationToken.None);

        Assert.NotNull(response);

    }

    [Fact]
    public async Task AuthorShould_UpdateAuthor()
    {
        string NameToUpdate = "MADAGASCAR";
        string LastNameToUpdate = "PRIMITIVES";
        await SetController();

        ListAuthorResponse response = await _controller.GetAllAsync(CancellationToken.None);
        var userToUpdate = response.Authors.FirstOrDefault();
        userToUpdate.Name = NameToUpdate;
        userToUpdate.LastName = LastNameToUpdate;

        UpdateAuthorRequest request2 = new UpdateAuthorRequest
        {
            Author = userToUpdate
        };

        UpdateAuthorResponse response2 = await _controller.UpdateAsync(request2, CancellationToken.None);

        Assert.NotNull(response2);
        Assert.True(response2.AuthorUpdated.Name.Equals(NameToUpdate));
        Assert.True(response2.AuthorUpdated.LastName.Equals(LastNameToUpdate));
    }

    [Fact]
    public async Task AuthorShould_GetFirstOfList()
    {
        await SetController();

        ListAuthorResponse response = await _controller.GetAllAsync(CancellationToken.None);

        Assert.NotNull(response);
        Assert.True(response.Authors.Any());
    }

    [Fact]
    public async Task AuthorShould_RemoveAuthor()
    {
        await SetController();

        ListAuthorResponse response = await _controller.GetAllAsync(CancellationToken.None);
        var author = response.Authors.FirstOrDefault();

        DeleteAuthorRequest request2 = new DeleteAuthorRequest
        {
            Id = author.Id
        };

        var response2 = await _controller.DeleteAsync(request2, CancellationToken.None);
        response = await _controller.GetAllAsync(CancellationToken.None);

        Assert.NotNull(response2);
        var found = response.Authors.FirstOrDefault(x => x.Id.Equals(response2.AuthorDeleted.Id));
        Assert.Null(found);
    }

    public async Task SetController()
    {
        ILoggerFactory _loggerFactory = LoggerFactory.Create(factory => factory.AddConsole());
        var keepAliveConnection = new SqliteConnection("DataSource=:memory:");
        keepAliveConnection.Open();
        var options = new DbContextOptionsBuilder<TravelBooksDbContext>().UseSqlite(keepAliveConnection).Options;
        var context = new TravelBooksDbContext(options);

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var authors = SampleAuthorsBooksAndEditorials.GetSampleAuthors();
        var editorials = SampleAuthorsBooksAndEditorials.GetSampleEditorial();
        var books = SampleAuthorsBooksAndEditorials.GetSampleBooks();

        await context.Authors.AddRangeAsync(authors);
        await context.SaveChangesAsync();

        await context.Editorials.AddRangeAsync(editorials);
        await context.SaveChangesAsync();

        Random random = new Random();
        foreach (var book in books)
        {
            book.EditorialId = editorials.ElementAt(random.Next(0, 1)).Id;
        }

        await context.Books.AddRangeAsync(books);
        await context.SaveChangesAsync();

        var bookss = context.Books.ToList();
        var authorss = context.Authors.ToList();

        var authorBooks = new List<AuthorsBooks>()
        {
            new AuthorsBooks
            {
                AuthorId = authorss.FirstOrDefault().Id,
                BookId = bookss.FirstOrDefault().ISBN,
            },
            new AuthorsBooks
            {
                AuthorId = authorss.LastOrDefault().Id,
                BookId = bookss.LastOrDefault().ISBN,
            }
        };

        var authorbybooks = from au in authorss
                            join ab in authorBooks
                            on au.Id equals ab.AuthorId
                            select ab;

        foreach (var author in authorss)
        {
            author.AuthorsBooks = authorbybooks.Where(x => x.AuthorId.Equals(author.Id)).ToList();
        }

        context.Authors.UpdateRange(authorss);
        await context.SaveChangesAsync();

        var authorService = new AuthorService(
            new AuthorRepository(
                _loggerFactory.CreateLogger<AsyncRepository<Author>>()
                , context),
            _loggerFactory.CreateLogger<AuthorService>());
        _controller = new AuthorsController(authorService);
    }
}
