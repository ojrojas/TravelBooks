namespace TravelBooks.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    /// <summary>
    /// Get Books App
    /// </summary>
    /// <returns>List Users</returns>
    [Produces("application/json")]
    [ProducesResponseType(typeof(IReadOnlyList<Book>), StatusCodes.Status200OK)]
    public async ValueTask<ListBooksResponse> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _bookService.GetAllBooksAsync(new ListBooksRequest(), cancellationToken);
    }


    [HttpPost]
    /// <summary>
    /// Post Book App
    /// </summary>
    /// <returns>User created</returns>
    [Produces("application/json")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    public async ValueTask<CreateBookResponse> CreateAsync([FromBody] CreateBookRequest request, CancellationToken cancellationToken)
    {
        return await _bookService.CreateBookAsync(request, cancellationToken);
    }


    [HttpPut]
    /// <summary>
    /// Put Book App
    /// </summary>
    /// <returns>User created</returns>
    [Produces("application/json")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    public async ValueTask<UpdateBookResponse> UpdateAsync(UpdateBookRequest request, CancellationToken cancellationToken)
    {
        return await _bookService.UpdateBookAsync(request, cancellationToken);
    }

    [HttpDelete("{Id}")]
    /// <summary>
    /// Delete Book App
    /// </summary>
    /// <returns>User created</returns>
    [Produces("application/json")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    public async ValueTask<DeleteBookResponse> DeleteAsync([FromRoute] DeleteBookRequest request, CancellationToken cancellationToken)
    {
        return await _bookService.DeleteBookAsync(request, cancellationToken);
    }
}
