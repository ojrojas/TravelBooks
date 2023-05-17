namespace TravelBooks.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EditorialsController : ControllerBase
{
    private readonly IEditorialService _editorialService;

    public EditorialsController(IEditorialService editorialService)
    {
        _editorialService = editorialService;
    }

    [HttpGet]
    /// <summary>
    /// Get Editorial App
    /// </summary>
    /// <returns>List Users</returns>
    [Produces("application/json")]
    [ProducesResponseType(typeof(IReadOnlyList<Editorial>), StatusCodes.Status200OK)]
    public async Task<ListEditorialResponse> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _editorialService.GetAllEditorialsAsync(new ListEditorialRequest(), cancellationToken);
    }


    [HttpPost]
    /// <summary>
    /// Post Editorial App
    /// </summary>
    /// <returns>User created</returns>
    [Produces("application/json")]
    [ProducesResponseType(typeof(Editorial), StatusCodes.Status200OK)]
    public async ValueTask<CreateEditorialResponse> CreateAsync([FromBody] CreateEditorialRequest request, CancellationToken cancellationToken)
    {
        return await _editorialService.CreateEditorialAsync(request, cancellationToken);
    }


    [HttpPut]
    /// <summary>
    /// Put Editorial App
    /// </summary>
    /// <returns>User created</returns>
    [Produces("application/json")]
    [ProducesResponseType(typeof(Editorial), StatusCodes.Status200OK)]
    public async ValueTask<UpdateEditorialResponse> UpdateAsync(UpdateEditorialRequest request, CancellationToken cancellationToken)
    {
        return await _editorialService.UpdateEditorialAsync(request, cancellationToken);
    }

    [HttpDelete("{Id}")]
    /// <summary>
    /// Delete Editorial App
    /// </summary>
    /// <returns>User created</returns>
    [Produces("application/json")]
    [ProducesResponseType(typeof(Editorial), StatusCodes.Status200OK)]
    public async ValueTask<DeleteEditorialResponse> DeleteAsync([FromRoute]DeleteEditorialRequest request, CancellationToken cancellationToken)
    {
        return await _editorialService.DeleteEditorialAsync(request, cancellationToken);
    }
}
