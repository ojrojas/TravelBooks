namespace TravelBooks.Identity.Interfaces;

/// <summary>
/// IApplicatioUser service 
/// </summary>
public interface IApplicationUserService
{
    /// <summary>
    /// Create user application
    /// </summary>
    /// <param name="request">Create user application request</param>
    /// <param name="cancellationToken">Cancellation request</param>
    /// <returns>Create application user response</returns>
    Task<CreateApplicationResponse> CreateUserApplicationAsync(CreateApplicationRequest request, CancellationToken cancellationToken);
    /// <summary>
    /// Delete user application
    /// </summary>
    /// <param name="request">Delete user application request</param>
    /// <param name="cancellationToken">Cancellation request</param>
    /// <returns>Delete user application response</returns>
    Task<DeleteApplicationUserResponse> DeleteUserApplicationAsync(DeleteApplicationUserRequest request, CancellationToken cancellationToken);
    /// <summary>
    /// Get all user applications 
    /// </summary>
    /// <param name="request">Get all user request</param>
    /// <param name="cancellationToken">Cancellatoken request</param>
    /// <returns>List all user application response</returns>
    Task<ListApplicationUserResponse> GetAllUserApplicationsAsync(ListApplicationUserRequest request, CancellationToken cancellationToken);
    /// <summary>
    /// Get application user 
    /// </summary>
    /// <param name="request">Get user by id request</param>
    /// <param name="cancellationToken">Cancellatio token request</param>
    /// <returns>Get user application response</returns>
    Task<GetApplicationUserByIdResponse> GetApplicationUserByIdAsync(GetApplicationUserByIdRequest request, CancellationToken cancellationToken);
    /// <summary>
    /// Login application
    /// </summary>
    /// <param name="request">Login application request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Login application response</returns>
    Task<LoginUserApplicationResponse> LoginAsync(LoginUserApplicationRequest request, CancellationToken cancellationToken);
    /// <summary>
    /// Update application user
    /// </summary>
    /// <param name="request">Update user application request</param>
    /// <param name="cancellationToken">Cancellation token request</param>
    /// <returns>Update user application respones</returns>
    Task<UpdateApplicationUserResponse> UpdateUserApplicationAsync(UpdateApplicationUserRequest request, CancellationToken cancellationToken);
}