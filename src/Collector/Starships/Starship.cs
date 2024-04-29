using Collector.ExternalModels.Starship;
using Collector.Helpers;
using Collector.Movies;

namespace Collector.Starships;

public sealed class Starship()
{
    public int Id { get; set; }
    public int Code { get; set; }
    public string Name { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string? CostInCredits { get; set; }
    public string Length { get; set; } = null!;
    public string MaxSpeed { get; set; } = null!;
    public string Crew { get; set; } = null!;
    public string Passengers { get; set; } = null!;
    public string CargoCapacity { get; set; } = null!;
    public string HyperdriveRating { get; set; } = null!;
    public string Mglt { get; set; } = null!;
    public string Consumables { get; set; } = null!;
    public string Class { get; set; } = null!;
    public int MovieCode { get; set; }
    public IList<Movie> Movies { get; set; } = [];

    private Starship(
        int code, 
        string name, 
        string model, 
        string manufacturer, 
        string? costInCredits, 
        string length, 
        string maxSpeed, 
        string crew, 
        string passengers, 
        string cargoCapacity,
        string hyperdriveRating,
        string mglt,
        string consumables, 
        string starshipClass, 
        int movieCode) : this()
    {
        Code = code;
        Name = name;
        Model = model;
        Manufacturer = manufacturer;
        CostInCredits = costInCredits;
        Length = length;
        MaxSpeed = maxSpeed;
        Crew = crew;
        Passengers = passengers;
        CargoCapacity = cargoCapacity;
        HyperdriveRating = hyperdriveRating;
        Mglt = mglt;
        Consumables = consumables;
        Class = starshipClass;
        MovieCode = movieCode;
    }
    
    public static IList<Starship> ToModel(IList<StarshipResultApi>? starships) => FromApiToModel(starships);
    
    private static IList<Starship> FromApiToModel(IList<StarshipResultApi>? starships)
    {
        if (starships is null) return new List<Starship>();

        return (from starship in starships
                from movie in starship.Films
                select new Starship(
                    code: Parsers.ExtractCodeFromUrl(starship.Url),
                    name: starship.Name,
                    model: starship.Model,
                    manufacturer: starship.Manufacturer,
                    costInCredits: starship.CostInCredits,
                    length: starship.Length,
                    maxSpeed: starship.MaxAtmospheringSpeed,
                    crew: starship.Crew,
                    passengers: starship.Passengers,
                    cargoCapacity: starship.CargoCapacity,
                    hyperdriveRating: starship.HyperdriveRating,
                    mglt: starship.Mglt,
                    consumables: starship.Consumables,
                    starshipClass: starship.StarshipClass,
                    movieCode: Parsers.ExtractCodeFromUrl(movie)))
            .ToList();
    }
}