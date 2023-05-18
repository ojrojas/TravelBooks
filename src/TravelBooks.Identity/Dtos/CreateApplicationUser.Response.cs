namespace TravelBooks.Identity.Dtos;

public record CreateApplicationResponse : BaseResponse
{
    public CreateApplicationResponse(Guid correlation) : base(correlation)
    {
    }

    public ApplicationUser ApplicationUserCreated { get; set; }
}

