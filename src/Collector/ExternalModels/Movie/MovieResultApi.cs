using System.Text.Json.Serialization;

namespace Collector.ExternalModels.Movie;

public record MovieResultApi()
{
    [JsonPropertyName("title")] public string Title { get; set; } = null!;
    [JsonPropertyName("episode_id")] public int EpisodeId { get; set; }
    [JsonPropertyName("opening_crawl")] public string OpeningCrawl { get; set; } = null!;
    [JsonPropertyName("director")] public string Director { get; set; } = null!;
    [JsonPropertyName("producer")] public string Producer { get; set; } = null!;
    [JsonPropertyName("release_date")] public string ReleaseDate { get; set; } = null!;
    [JsonPropertyName("characters")] public IList<string> Characters { get; set; } = [];
    [JsonPropertyName("planets")] public IList<string> Planets { get; set; } = [];
    [JsonPropertyName("starships")] public IList<string> Starships { get; set; } = [];
    [JsonPropertyName("vehicles")] public IList<string> Vehicles { get; set; } = [];
    [JsonPropertyName("species")] public IList<string> Species { get; set; } = [];
    [JsonPropertyName("created")] public string Created { get; set; } = null!;
    [JsonPropertyName("edited")] public string Edited { get; set; } = null!;
    [JsonPropertyName("url")] public string Url { get; set; } = null!;
}