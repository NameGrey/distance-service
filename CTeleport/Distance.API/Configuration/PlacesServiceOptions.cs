namespace Distance.API.Configuration;

public class PlacesServiceOptions
{
    public string Url { get; set; }
    public short RetryCount { get; set; }
    public TimeSpan Timeout { get; set; }
}