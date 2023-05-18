namespace TravelBooks.Core.Dtos;

public record GetBookByIdRequest : BaseRequest
{
    public Guid Id { get; set; }
}

