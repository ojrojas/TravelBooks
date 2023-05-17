namespace TravelBooks.Identity.Dtos;

public record UpdateApplicationUserResponse: BaseResponse
{
	public UpdateApplicationUserResponse(Guid correlation): base(correlation)
	{
	}

	public ApplicationUser ApplicationUserUpdated { get; set; }
}

