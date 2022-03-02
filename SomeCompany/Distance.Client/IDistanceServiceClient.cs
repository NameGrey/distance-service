namespace Distance.Client;

public interface IDistanceServiceClient
{
    Task<double> GetDistance(string fromIata, string toIata);
}