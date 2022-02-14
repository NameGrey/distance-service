using System.Text.Json;
using Places.Client.Models;

namespace Places.Client;

public class PlacesServiceClient: IPlacesServiceClient
{
    private readonly HttpClient _apiClient;

    public PlacesServiceClient(HttpClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<AirportDetails> GetAirportDetails(string airportCode)
    {
        var response = await _apiClient.GetAsync($"airports/{airportCode}");

        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<AirportDetails>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (result == null)
        {
            // Result can be null when service's API has changed, but one service was deployed earlier than another
            // This exception will allow us to use Retry policy
            throw new HttpRequestException("Incorrect response from Places service. Please check if API has changed");
        }

        return result;
    }
}