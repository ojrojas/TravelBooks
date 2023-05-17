namespace TravelBooks.Core.Dtos;

public record CreateAuthorRequest : BaseRequest
{
    public Author Author { get; set; } = null!;
}

