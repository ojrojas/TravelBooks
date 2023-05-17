namespace TravelBooks.Core.Interfaces
{
    public interface IBookService
    {
        ValueTask<CreateBookResponse> CreateBookAsync(CreateBookRequest request, CancellationToken cancellationToken);
        ValueTask<DeleteBookResponse> DeleteBookAsync(DeleteBookRequest request, CancellationToken cancellationToken);
        ValueTask<ListBooksResponse> GetAllBooksAsync(ListBooksRequest request, CancellationToken cancellationToken);
        ValueTask<UpdateBookResponse> UpdateBookAsync(UpdateBookRequest request, CancellationToken cancellationToken);
    }
}