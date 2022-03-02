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

        return result;
    }
}