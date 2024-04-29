using Collector.ExternalModels.Vehicle;
using Collector.Helpers;
using Collector.Movies;

namespace Collector.Vehicles;

public sealed class Vehicle()
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
    public string Consumables { get; set; } = null!;
    public string Class { get; set; } = null!;
    public int MovieCode { get; set; }
    public IList<Movie> Movies { get; set; } = [];

    private Vehicle(
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
        string consumables, 
        string vehicleClass, 
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
        Consumables = consumables;
        Class = vehicleClass;
        MovieCode = movieCode;
    }
    
    public static IList<Vehicle> ToModel(IList<VehicleResultApi>? vehicles) => FromApiToModel(vehicles);
    
    private static IList<Vehicle> FromApiToModel(IList<VehicleResultApi>? vehicles)
    {
        if (vehicles is null) return new List<Vehicle>();

        return (from vehicle in vehicles
                from movie in vehicle.Films
                select new Vehicle(
                    code: Parsers.ExtractCodeFromUrl(vehicle.Url),
                    name: vehicle.Name,
                    model: vehicle.Model,
                    manufacturer: vehicle.Manufacturer,
                    costInCredits: vehicle.CostInCredits,
                    length: vehicle.Length,
                    maxSpeed: vehicle.MaxAtmospheringSpeed,
                    crew: vehicle.Crew,
                    passengers: vehicle.Passengers,
                    cargoCapacity: vehicle.CargoCapacity,
                    consumables: vehicle.Consumables,
                    vehicleClass: vehicle.VehicleClass,
                    movieCode: Parsers.ExtractCodeFromUrl(movie)))
            .ToList();
    }
}