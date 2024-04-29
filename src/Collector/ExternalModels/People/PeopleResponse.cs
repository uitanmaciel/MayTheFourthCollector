using System.Text.Json.Serialization;
using Collector.ExternalModels.Movie;

namespace Collector.ExternalModels.People;

public record PeopleResponse
{
    [JsonPropertyName("count")] public int Count { get; set; }
    [JsonPropertyName("next")] public string? Next { get; set; }
    [JsonPropertyName("previous")] public string? Previous { get; set; }
    [JsonPropertyName("results")] public IList<PeopleResultApi> Results { get; set; } = [];
}