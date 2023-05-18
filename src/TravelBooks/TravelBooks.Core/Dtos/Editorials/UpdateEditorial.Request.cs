namespace TravelBooks.Core.Dtos;

public record UpdateEditorialRequest : BaseRequest
{
    public Editorial Editorial { get; set; } = null!;
}

