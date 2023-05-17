namespace TravelBooks.Identity.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class DeleteApplicationUser : ControllerBase
{
	private readonly IApplicationUserService _service;

    public DeleteApplicationUser(IApplicationUserService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpDelete("{Id}")]
    [SwaggerOperation(
      Summary = "Delete applicationuser",
      Description = "Delete applicationuser",
      OperationId = "applicationuser.deleteapplicationuser",
      Tags = new[] { "ApplicationUserEndpoint" })]
    public async ValueTask<DeleteApplicationUserResponse> Handle([FromRoute]DeleteApplicationUserRequest request, CancellationToken cancellationToken)
	{
		return await _service.DeleteUserApplicationAsync(request, cancellationToken);
	}
}

