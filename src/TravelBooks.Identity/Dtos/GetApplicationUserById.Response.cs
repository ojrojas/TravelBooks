using System;
namespace TravelBooks.Identity.Dtos;

public record GetApplicationUserByIdResponse: BaseResponse
{
	public GetApplicationUserByIdResponse(Guid correlation):base(correlation)
	{
	}

	public ApplicationUser ApplicationUserFound { get; set; }
}

