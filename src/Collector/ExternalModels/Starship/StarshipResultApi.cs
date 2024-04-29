using System.Text.Json.Serialization;

namespace Collector.ExternalModels.Starship;

public record StarshipResultApi
{
    [JsonPropertyName("name")] public string Name { get; set; } = null!;
    [JsonPropertyName("model")] public string Model { get; set; } = null!;
    [JsonPropertyName("manufacturer")] public string Manufacturer { get; set; } = null!;
    [JsonPropertyName("cost_in_credits")] public string CostInCredits { get; set; } = null!;
    [JsonPropertyName("length")] public string Length { get; set; } = null!;
    [JsonPropertyName("max_atmosphering_speed")] public string MaxAtmospheringSpeed { get; set; } = null!;
    [JsonPropertyName("crew")] public string Crew { get; set; } = null!;
    [JsonPropertyName("passengers")] public string Passengers { get; set; } = null!;
    [JsonPropertyName("cargo_capacity")] public string CargoCapacity { get; set; } = null!;
    [JsonPropertyName("consumables")] public string Consumables { get; set; } = null!;
    [JsonPropertyName("hyperdrive_rating")] public string HyperdriveRating { get; set; } = null!;
    [JsonPropertyName("MGLT")] public string Mglt { get; set; } = null!;
    [JsonPropertyName("starship_class")] public string StarshipClass { get; set; } = null!;
    [JsonPropertyName("pilots")] public IList<string> Pilots { get; set; } = [];
    [JsonPropertyName("films")] public IList<string> Films { get; set; } = [];
    [JsonPropertyName("created")] public string Created { get; set; } = null!;
    [JsonPropertyName("edited")] public string Edited { get; set; } = null!;
    [JsonPropertyName("url")] public string Url { get; set; } = null!;
}