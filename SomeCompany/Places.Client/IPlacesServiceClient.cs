using Places.Client.Models;

namespace Places.Client;

public interface IPlacesServiceClient
{
    Task<AirportDetails> GetAirportDetails(string airportCode);
}