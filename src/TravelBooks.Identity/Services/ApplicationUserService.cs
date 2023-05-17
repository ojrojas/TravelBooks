using TravelBooks.Identity.Infraestructure;

namespace TravelBooks.Identity.Services;

public class ApplicationUserService : IApplicationUserService
{
    private readonly IdentityRepository _repository;
    private readonly IEncryptService _encryptService;
    private readonly ILogger<ApplicationUserService> _logger;
    private readonly ITokenService<ApplicationUser> _tokenService;

    public ApplicationUserService(IdentityRepository repository,
                                  IEncryptService encryptService,
                                  ILogger<ApplicationUserService> logger,
                                  ITokenService<ApplicationUser> tokenService)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _encryptService = encryptService ?? throw new ArgumentNullException(nameof(encryptService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
    }

    public async Task<CreateApplicationResponse> CreateUserApplicationAsync(CreateApplicationRequest request, CancellationToken cancellationToken)
    {
        CreateApplicationResponse response = new(request.Correlation);
        if (request.ApplicationUser is null) throw new ArgumentNullException(nameof(request.ApplicationUser));
        request.ApplicationUser.UserName = request.ApplicationUser.UserName.ToLowerInvariant();
        request.ApplicationUser.Password = await _encryptService.Encrypt(request.ApplicationUser.Password);
        _logger.LogInformation($"Create user application {JsonSerializer.Serialize(request.ApplicationUser)}");
        response.ApplicationUserCreated = await _repository.CreateAsync(request.ApplicationUser, cancellationToken);
        return response;
    }

    public async Task<UpdateApplicationUserResponse> UpdateUserApplicationAsync(UpdateApplicationUserRequest request, CancellationToken cancellationToken)
    {
        UpdateApplicationUserResponse response = new(request.Correlation);
        if (request.ApplicationUser is null) throw new ArgumentNullException(nameof(request.ApplicationUser));
        request.ApplicationUser.UserName = request.ApplicationUser.UserName.ToLowerInvariant();
        request.ApplicationUser.Password = await _encryptService.Encrypt(request.ApplicationUser.Password);
        _logger.LogInformation($"Update user application {JsonSerializer.Serialize(request.ApplicationUser)}");
        response.ApplicationUserUpdated = await _repository.UpdateAsync(request.ApplicationUser, cancellationToken);
        return response;
    }

    public async Task<DeleteApplicationUserResponse> DeleteUserApplicationAsync(DeleteApplicationUserRequest request, CancellationToken cancellationToken)
    {
        DeleteApplicationUserResponse response = new(request.Correlation);
        if (request.Id.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(request));
        ApplicationUser userApplication = await _repository.GetByIdAsync(request.Id, cancellationToken);
        response.ApplicationUserDeleted = await _repository.DeleteAsync(userApplication, cancellationToken);
        return response;
    }

    public async Task<ListApplicationUserResponse> GetAllUserApplicationsAsync(ListApplicationUserRequest request, CancellationToken cancellationToken)
    {
        ListApplicationUserResponse response = new(request.Correlation);
        _logger.LogInformation($"Get all user applications request");
        response.ApplicationUsers = await _repository.ListAsync(cancellationToken);
        return response;
    }

    public async Task<GetApplicationUserByIdResponse> GetApplicationUserByIdAsync(GetApplicationUserByIdRequest request, CancellationToken cancellationToken)
    {
        GetApplicationUserByIdResponse response = new(request.Correlation);
        _logger.LogInformation($"Get user application by id request");
        response.ApplicationUserFound = await _repository.GetByIdAsync(request.Id, cancellationToken);
        return response;
    }

    public async Task<LoginUserApplicationResponse> LoginAsync(LoginUserApplicationRequest request, CancellationToken cancellationToken)
    {
        LoginUserApplicationResponse response = new(request.Correlation);
        _logger.LogInformation($"Encrypt password and get user by login");
        request.Password = await _encryptService.Encrypt(request.Password);
        request.UserName = request.UserName.ToLowerInvariant();
        ApplicationUserSpecification specification = new(request.UserName, request.Password);
        var result = await _repository.FirstOrDefaultAsync(specification, cancellationToken);
        if (result is not null)
            response.Token = await _tokenService.GetTokenAsync(result);
        return response;
    }
}

