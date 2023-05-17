namespace TravelBooks.Identity.Dtos;

public record CreateApplicationRequest: BaseRequest
{
	public ApplicationUser ApplicationUser { get; set; }
}

