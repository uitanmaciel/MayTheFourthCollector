using System.Text.Json.Serialization;

namespace Collector.ExternalModels.Starship;

public record StarshipResponse
{
    [JsonPropertyName("count")] public int Count { get; set; }
    [JsonPropertyName("next")] public string? Next { get; set; }
    [JsonPropertyName("previous")] public string? Previous { get; set; }
    [JsonPropertyName("results")] public IList<StarshipResultApi> Results { get; set; } = [];
}