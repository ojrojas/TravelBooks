namespace TravelBooks.Commons.Request;

public record BaseResponse: BaseMessage
{
	public BaseResponse(Guid correlation) : base() => _correlation = correlation;
}

