namespace TravelBooks.Identity.Endpoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CreateApplicationUser : ControllerBase
{
    private readonly IApplicationUserService _service;

    public CreateApplicationUser(IApplicationUserService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost]
    [Consumes("application/json")]
    [Produces(typeof(CreateApplicationResponse))]
    [SwaggerOperation(
      Summary = "Create applicationuser",
      Description = "Create applicationuser",
      OperationId = "applicationuser.createapplicationuser",
      Tags = new[] { "ApplicationUserEndpoint" })]
    public async ValueTask<CreateApplicationResponse> Handle(CreateApplicationRequest request, CancellationToken cancellationToken)
    {
        return await _service.CreateUserApplicationAsync(request, cancellationToken);
    }
}

