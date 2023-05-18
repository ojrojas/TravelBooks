namespace TravelBooks.Core.Dtos;

public record GetAuthorByIdRequest : BaseRequest
{
    public Guid Id { get; set; }
}

