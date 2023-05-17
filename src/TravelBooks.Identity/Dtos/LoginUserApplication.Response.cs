namespace TravelBooks.Identity.Dtos;

public record LoginUserApplicationResponse : BaseResponse
{
    public LoginUserApplicationResponse(Guid correlation) : base(correlation)
    {
    }

    public string Token { get; set; }
}

