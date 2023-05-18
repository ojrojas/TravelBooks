namespace TravelBooks.Identity.Endpoints;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GetApplicationUserById : ControllerBase
{
    private readonly IApplicationUserService _service;

    public GetApplicationUserById(IApplicationUserService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet("{Id}")]
    [SwaggerOperation(
      Summary = "Get applicationuser",
      Description = "Get applicationuser",
      OperationId = "applicationuser.getapplicationuserbyid",
      Tags = new[] { "ApplicationUserEndpoint" })]
    public async ValueTask<GetApplicationUserByIdResponse> Handle([FromRoute] GetApplicationUserByIdRequest request, CancellationToken cancellationToken)
    {
        return await _service.GetApplicationUserByIdAsync(request, cancellationToken);
    }
}

