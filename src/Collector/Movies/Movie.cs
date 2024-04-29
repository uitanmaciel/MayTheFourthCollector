using Collector.ExternalModels.Movie;
using Collector.Helpers;
using Collector.Peoples;
using Collector.Planets;
using Collector.Starships;
using Collector.Vehicles;

namespace Collector.Movies;

public sealed class Movie()
{
    public int Id { get; set; }
    public int Code { get; set; }
    public string Title { get; set; } = null!;
    public int Episode { get; set; }
    public string OpeningCrawl { get; set; } = null!;
    public string Director { get; set; } = null!;
    public string Producer { get; set; } = null!;
    public string ReleaseDate { get; set; } = null!;
    public int CharacterCode { get; set; }
    public int PlanetCode { get; set; }
    public int VehicleCode { get; set; }
    public int StarshipCode { get; set; }
    public IList<People> Characters { get; set; } = [];
    public IList<Planet> Planets { get; set; } = [];
    public IList<Vehicle> Vehicles { get; set; } = [];
    public IList<Starship> Starships { get; set; } = [];

    private Movie(
        int code, 
        string title, 
        int episode, 
        string openingCrawl, 
        string director, 
        string producer, 
        string releaseDate, 
        int characterCode, 
        int planetCode, 
        int vehicleCode, 
        int starshipCode) : this()
    {
        Code = code;
        Title = title;
        Episode = episode;
        OpeningCrawl = openingCrawl;
        Director = director;
        Producer = producer;
        ReleaseDate = releaseDate;
        CharacterCode = characterCode;
        PlanetCode = planetCode;
        VehicleCode = vehicleCode;
        StarshipCode = starshipCode;
    }
    public static IList<Movie> ToModel(IList<MovieResultApi>? movies) => FromApiToModel(movies);

    private static IList<Movie> FromApiToModel(IList<MovieResultApi>? movies)
    {
        if (movies is null) return new List<Movie>();

        return (from movie in movies
                from character in movie.Characters 
                from planet in movie.Planets 
                from vehicle in movie.Vehicles 
                from starship in movie.Starships 
                select new Movie(
                    code: Parsers.ExtractCodeFromUrl(movie.Url), 
                    title: movie.Title, 
                    episode: movie.EpisodeId, 
                    openingCrawl: movie.OpeningCrawl.Replace("\r\n", " "),
                    director: movie.Director, 
                    producer: movie.Producer, 
                    releaseDate: movie.ReleaseDate, 
                    characterCode: Parsers.ExtractCodeFromUrl(character), 
                    planetCode: Parsers.ExtractCodeFromUrl(planet), 
                    vehicleCode: Parsers.ExtractCodeFromUrl(vehicle), 
                    starshipCode: Parsers.ExtractCodeFromUrl(starship)))
                .ToList();
    }
}