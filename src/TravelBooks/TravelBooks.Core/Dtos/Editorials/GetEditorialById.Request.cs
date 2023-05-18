namespace TravelBooks.Core.Dtos;

public record GetEditorialByIdRequest : BaseRequest
{
    public Guid Id { get; set; }
}

