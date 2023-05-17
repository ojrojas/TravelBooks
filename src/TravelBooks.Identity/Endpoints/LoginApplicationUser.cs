namespace TravelBooks.Identity.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class LoginApplicationUser : ControllerBase
{
    private readonly IApplicationUserService _service;

    public LoginApplicationUser(IApplicationUserService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpPost("Login")]
    [SwaggerOperation(
      Summary = "Login applicationuser",
      Description = "Login list applicationuser",
      OperationId = "applicationuser.loginapplicationuser",
      Tags = new[] { "ApplicationUserEndpoint" })]
    public async ValueTask<LoginUserApplicationResponse> Handle(LoginUserApplicationRequest request, CancellationToken cancellationToken)
    {
        return await _service.LoginAsync(request, cancellationToken);
    }
}