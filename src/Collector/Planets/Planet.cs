using Collector.ExternalModels.Planet;
using Collector.Helpers;
using Collector.Movies;
using Collector.Peoples;

namespace Collector.Planets;

public sealed class Planet()
{
    public int Id { get; set; }
    public int Code { get; set; }
    public string Name { get; set; } = null!;
    public string RotationPeriod { get; set; } = null!;
    public string OrbitalPeriod { get; set; } = null!;
    public string Diameter { get; set; } = null!;
    public string Climate { get; set; } = null!;
    public string Gravity { get; set; } = null!;
    public string Terrain { get; set; } = null!;
    public string SurfaceWater { get; set; } = null!;
    public string Population { get; set; } = null!;
    public int CharacterCode { get; set; }
    public int MovieCode { get; set; }
    public IList<People> Characters { get; set; } = [];
    public IList<Movie> Movies { get; set; } = [];
    
    private Planet(
        int code, 
        string name, 
        string rotationPeriod, 
        string orbitalPeriod, 
        string diameter, 
        string climate, 
        string gravity, 
        string terrain, 
        string surfaceWater, 
        string population, 
        int characterCode, 
        int movieCode) : this()
    {
        Code = code;
        Name = name;
        RotationPeriod = rotationPeriod;
        OrbitalPeriod = orbitalPeriod;
        Diameter = diameter;
        Climate = climate;
        Gravity = gravity;
        Terrain = terrain;
        SurfaceWater = surfaceWater;
        Population = population;
        CharacterCode = characterCode;
        MovieCode = movieCode;
    }
    
    public static IList<Planet> ToModel(IList<PlanetResultApi>? planets) => FromApiToModel(planets);
    
    private static IList<Planet> FromApiToModel(IList<PlanetResultApi>? planets)
    {
        if (planets is null) return new List<Planet>();

        return (from planet in planets 
                from character in planet.Residents 
                from movie in planet.Films 
                select new Planet(
                    code: Parsers.ExtractCodeFromUrl(planet.Url), 
                    name: planet.Name, 
                    rotationPeriod: planet.RotationPeriod, 
                    orbitalPeriod: planet.OrbitalPeriod, 
                    diameter: planet.Diameter, 
                    climate: planet.Climate, 
                    gravity: planet.Gravity, 
                    terrain: planet.Terrain, 
                    surfaceWater: planet.SurfaceWater, 
                    population: planet.Population, 
                    characterCode: Parsers.ExtractCodeFromUrl(character), 
                    movieCode: Parsers.ExtractCodeFromUrl(movie)))
                .ToList();
    }
}