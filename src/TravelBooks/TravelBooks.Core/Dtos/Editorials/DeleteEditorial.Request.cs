namespace TravelBooks.Core.Dtos;

public record DeleteEditorialRequest : BaseRequest
{
    public Guid Id { get; set; }
}

