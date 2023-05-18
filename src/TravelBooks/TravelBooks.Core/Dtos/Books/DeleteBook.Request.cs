namespace TravelBooks.Core.Dtos;

public record DeleteBookRequest : BaseRequest
{
    public Guid Id { get; set; }
}

