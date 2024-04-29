using System.Text.Json.Serialization;
using Collector.ExternalModels.People;

namespace Collector.ExternalModels.Planet;

public record PlanetResponse
{
    [JsonPropertyName("count")] public int Count { get; set; }
    [JsonPropertyName("next")] public string? Next { get; set; }
    [JsonPropertyName("previous")] public string? Previous { get; set; }
    [JsonPropertyName("results")] public IList<PlanetResultApi> Results { get; set; } = [];
}