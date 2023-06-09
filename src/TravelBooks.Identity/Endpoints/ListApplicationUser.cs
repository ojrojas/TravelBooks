﻿namespace TravelBooks.Identity.Endpoints;

[Authorize]

[ApiController]
[Route("api/[controller]")]
public class ListApplicationUser : ControllerBase
{
    private readonly IApplicationUserService _service;

    public ListApplicationUser(IApplicationUserService service)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet]
    [SwaggerOperation(
      Summary = "Get list applicationuser",
      Description = "Get list applicationuser",
      OperationId = "applicationuser.getlistapplicationusers",
      Tags = new[] { "ApplicationUserEndpoint" })]
    public async ValueTask<ListApplicationUserResponse> ListUserApplication(CancellationToken cancellationToken)
    {
        return await _service.GetAllUserApplicationsAsync(new ListApplicationUserRequest(), cancellationToken);
    }
}

