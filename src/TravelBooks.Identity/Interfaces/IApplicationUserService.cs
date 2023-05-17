namespace TravelBooks.Identity.Interfaces;

public interface IApplicationUserService
{
    Task<CreateApplicationResponse> CreateUserApplicationAsync(CreateApplicationRequest request, CancellationToken cancellationToken);
    Task<DeleteApplicationUserResponse> DeleteUserApplicationAsync(DeleteApplicationUserRequest request, CancellationToken cancellationToken);
    Task<ListApplicationUserResponse> GetAllUserApplicationsAsync(ListApplicationUserRequest request, CancellationToken cancellationToken);
    Task<GetApplicationUserByIdResponse> GetApplicationUserByIdAsync(GetApplicationUserByIdRequest request, CancellationToken cancellationToken);
    Task<LoginUserApplicationResponse> LoginAsync(LoginUserApplicationRequest request, CancellationToken cancellationToken);
    Task<UpdateApplicationUserResponse> UpdateUserApplicationAsync(UpdateApplicationUserRequest request, CancellationToken cancellationToken);
}