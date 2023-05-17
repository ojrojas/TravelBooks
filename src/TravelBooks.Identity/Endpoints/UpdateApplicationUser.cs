namespace TravelBooks.Identity.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class UpdateApplicationUser: ControllerBase
{
    private readonly IApplicationUserService _service;

    public UpdateApplicationUser(IApplicationUserService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPatch]
    [SwaggerOperation(
      Summary = "Update applicationuser",
      Description = "Update applicationuser",
      OperationId = "applicationuser.updateapplicationuser",
      Tags = new[] { "ApplicationUserEndpoint" })]
    public async ValueTask<UpdateApplicationUserResponse> UpdateUserApplication(UpdateApplicationUserRequest request, CancellationToken cancellationToken)
    {
        return await _service.UpdateUserApplicationAsync(request, cancellationToken);
    }
}


