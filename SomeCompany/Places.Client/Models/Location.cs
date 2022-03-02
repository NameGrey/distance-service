using System.Text.Json.Serialization;

namespace Places.Client.Models;

public record Location([property: JsonPropertyName("lon")] decimal Longitude, [property: JsonPropertyName("lat")] decimal Latitude);