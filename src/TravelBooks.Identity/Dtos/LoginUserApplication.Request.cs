namespace TravelBooks.Identity.Dtos;

public record LoginUserApplicationRequest: BaseRequest
{
	public string UserName { get; set; }
	public string Password { get; set; }
}

