namespace TravelBooks.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    /// <summary>
    /// Get Author App
    /// </summary>
    /// <returns>List Users</returns>
    [Produces("application/json")]
    [ProducesResponseType(typeof(IReadOnlyList<Author>), StatusCodes.Status200OK)]
    public async ValueTask<ListAuthorResponse> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _authorService.GetAllAuthorsAsync(new ListAuthorRequest(), cancellationToken);
    }


    [HttpPost]
    /// <summary>
    /// Post Editorial App
    /// </summary>
    /// <returns>User created</returns>
    [Produces("application/json")]
    [ProducesResponseType(typeof(Author), StatusCodes.Status200OK)]
    public async ValueTask<CreateAuthorResponse> CreateAsync([FromBody] CreateAuthorRequest request, CancellationToken cancellationToken)
    {
        return await _authorService.CreateAuthorAsync(request, cancellationToken);
    }


    [HttpPut]
    /// <summary>
    /// Put Author  App
    /// </summary>
    /// <returns>User created</returns>
    [Produces("application/json")]
    [ProducesResponseType(typeof(Editorial), StatusCodes.Status200OK)]
    public async ValueTask<UpdateAuthorResponse> UpdateAsync(UpdateAuthorRequest request, CancellationToken cancellationToken)
    {
        return await _authorService.UpdateAuthorAsync(request, cancellationToken);
    }

    [HttpDelete("{Id}")]
    /// <summary>
    /// Delete author App
    /// </summary>
    /// <returns>User created</returns>
    [Produces("application/json")]
    [ProducesResponseType(typeof(Editorial), StatusCodes.Status200OK)]
    public async ValueTask<DeleteAuthorResponse> DeleteAsync([FromRoute]DeleteAuthorRequest request, CancellationToken cancellationToken)
    {
        return await _authorService.DeleteAuthorAsync(request, cancellationToken);
    }
}
