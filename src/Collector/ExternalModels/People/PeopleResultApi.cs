using System.Text.Json.Serialization;

namespace Collector.ExternalModels.People;

public record PeopleResultApi()
{
    [JsonPropertyName("name")] public string Name { get; set; } = null!;
    [JsonPropertyName("height")] public string Height { get; set; } = null!;
    [JsonPropertyName("mass")] public string Mass { get; set; } = null!;
    [JsonPropertyName("hair_color")] public string HairColor { get; set; } = null!;
    [JsonPropertyName("skin_color")] public string SkinColor { get; set; } = null!;
    [JsonPropertyName("eye_color")] public string EyeColor { get; set; } = null!;
    [JsonPropertyName("birth_year")] public string BirthYear { get; set; } = null!;
    [JsonPropertyName("gender")] public string Gender { get; set; } = null!;
    [JsonPropertyName("homeworld")] public string Homeworld { get; set; } = null!;
    [JsonPropertyName("films")] public IList<string> Films { get; set; } = [];
    [JsonPropertyName("species")] public IList<string> Species { get; set; } = [];
    [JsonPropertyName("vehicles")] public IList<string> Vehicles { get; set; } = [];
    [JsonPropertyName("starships")] public IList<string> Starships { get; set; } = [];
    [JsonPropertyName("created")] public string Created { get; set; } = null!;
    [JsonPropertyName("edited")] public string Edited { get; set; } = null!;
    [JsonPropertyName("url")] public string Url { get; set; } = null!;
}