namespace TravelBooks.Core.Dtos;

public record CreateBookRequest : BaseRequest
{
    public Book Book { get; set; } = null!;
}

