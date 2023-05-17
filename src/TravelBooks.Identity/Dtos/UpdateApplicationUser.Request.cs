namespace TravelBooks.Identity.Dtos;

public record UpdateApplicationUserRequest: BaseRequest
{
	public ApplicationUser ApplicationUser { get; set; }
}

