using System.Text.Json.Serialization;

namespace Places.Client.Models;

public record AirportDetails(
    string Country,
    int Rating,
    string Name,
    string Type,
    int Hubs,
    string City,
    Location Location,
    [property: JsonPropertyName("city_iata")] string CityIata,
    [property: JsonPropertyName("iata")] string Iata,
    [property: JsonPropertyName("timezone_region_name")] string TimeZoneRegionName,
    [property: JsonPropertyName("country_iata")] string CountryIata
);