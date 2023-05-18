namespace TravelBooks.Core.Dtos;

public record UpdateAuthorResponse : BaseResponse
{
    public UpdateAuthorResponse(Guid correlation) : base(correlation) { }
    public Author AuthorUpdated { get; set; } = null!;
}

