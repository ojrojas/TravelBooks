namespace TravelBooks.Commons.Request;

public record BaseMessage
{
    protected Guid _correlation = Guid.NewGuid();
    public Guid Correlation => _correlation;
}

