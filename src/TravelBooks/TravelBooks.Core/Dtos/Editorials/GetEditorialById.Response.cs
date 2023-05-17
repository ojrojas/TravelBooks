using System;
namespace TravelBooks.Core.Dtos;

public record GetEditorialByIdResponse: BaseResponse
{
	public GetEditorialByIdResponse(Guid correlation): base(correlation)
	{
	}

	public Editorial EditorialFound { get; set; } = null;
}

