namespace TravelBooks.Identity.Dtos;

public record DeleteApplicationUserResponse: BaseResponse
{
	public DeleteApplicationUserResponse(Guid correlation): base(correlation)
	{
	}

	public ApplicationUser ApplicationUserDeleted { get; set; }
}

