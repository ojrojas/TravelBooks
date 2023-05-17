using System;
namespace TravelBooks.Core.Dtos;

public record ListEditorialResponse: BaseResponse
{
	public ListEditorialResponse(Guid correlation): base(correlation)
	{
	}

	public IEnumerable<Editorial> Editorials { get; set; } = null!;
}

