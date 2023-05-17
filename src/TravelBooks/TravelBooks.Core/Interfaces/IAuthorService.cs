namespace TravelBooks.Core.Interfaces
{
    public interface IAuthorService
    {
        ValueTask<CreateAuthorResponse> CreateAuthorAsync(CreateAuthorRequest request, CancellationToken cancellationToken);
        ValueTask<DeleteAuthorResponse> DeleteAuthorAsync(DeleteAuthorRequest request, CancellationToken cancellationToken);
        Task<ListAuthorResponse> GetAllAuthorsAsync(ListAuthorRequest request, CancellationToken cancellationToken);
        Task<GetAuthorByIdResponse> GetAuthorByIdAsync(GetAuthorByIdRequest request, CancellationToken cancellationToken);
        Task<UpdateAuthorResponse> UpdateAuthorAsync(UpdateAuthorRequest request, CancellationToken cancellationToken);
    }
}