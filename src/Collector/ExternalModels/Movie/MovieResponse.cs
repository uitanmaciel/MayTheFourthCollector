using System.Text.Json.Serialization;

namespace Collector.ExternalModels.Movie;

public record MovieResponse
{
    [JsonPropertyName("count")] public int Count { get; set; }
    [JsonPropertyName("next")] public string? Next { get; set; }
    [JsonPropertyName("previous")] public string? Previous { get; set; }
    [JsonPropertyName("results")] public IList<MovieResultApi> Results { get; set; } = [];
}