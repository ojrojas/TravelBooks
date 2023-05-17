namespace TravelBooks.Core.Interfaces
{
    public interface IEditorialService
    {
        ValueTask<CreateEditorialResponse> CreateEditorialAsync(CreateEditorialRequest request, CancellationToken cancellationToken);
        ValueTask<DeleteEditorialResponse> DeleteEditorialAsync(DeleteEditorialRequest request, CancellationToken cancellationToken);
        ValueTask<ListEditorialResponse> GetAllEditorialsAsync(ListEditorialRequest request, CancellationToken cancellationToken);
        ValueTask<UpdateEditorialResponse> UpdateEditorialAsync(UpdateEditorialRequest request, CancellationToken cancellationToken);
    }
}