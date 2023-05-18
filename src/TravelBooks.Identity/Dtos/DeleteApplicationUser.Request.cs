namespace TravelBooks.Identity.Dtos;

public record DeleteApplicationUserRequest : BaseRequest
{
    public Guid Id { get; set; }
}

