using System.Text.Json.Serialization;

namespace Collector.ExternalModels.Planet;

public record PlanetResultApi()
{
    [JsonPropertyName("name")] public string Name { get; set; } = null!;
    [JsonPropertyName("rotation_period")] public string RotationPeriod { get; set; } = null!;
    [JsonPropertyName("orbital_period")] public string OrbitalPeriod { get; set; } = null!;
    [JsonPropertyName("diameter")] public string Diameter { get; set; } = null!;
    [JsonPropertyName("climate")] public string Climate { get; set; } = null!;
    [JsonPropertyName("gravity")] public string Gravity { get; set; } = null!;
    [JsonPropertyName("terrain")] public string Terrain { get; set; } = null!;
    [JsonPropertyName("surface_water")] public string SurfaceWater { get; set; } = null!;
    [JsonPropertyName("population")] public string Population { get; set; } = null!;
    [JsonPropertyName("residents")] public IList<string> Residents { get; set; } = [];
    [JsonPropertyName("films")] public IList<string> Films { get; set; } = [];
    [JsonPropertyName("created")] public string Created { get; set; } = null!;
    [JsonPropertyName("edited")] public string Edited { get; set; } = null!;
    [JsonPropertyName("url")] public string Url { get; set; } = null!;
}