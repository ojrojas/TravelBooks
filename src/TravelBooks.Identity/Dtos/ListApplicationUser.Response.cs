namespace TravelBooks.Identity.Dtos;

public record ListApplicationUserResponse : BaseResponse
{
    public ListApplicationUserResponse(Guid correlation) : base(correlation)
    {
    }

    public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
}

