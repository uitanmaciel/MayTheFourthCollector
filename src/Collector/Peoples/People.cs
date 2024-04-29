using Collector.ExternalModels.People;
using Collector.Helpers;
using Collector.Movies;
using Collector.Planets;

namespace Collector.Peoples;

public sealed class People()
{
    public int Id { get; set; }
    public int Code { get; set; }
    public string Name { get; set; } = null!;
    public string Height { get; set; } = null!;
    public string Weight { get; set; } = null!;
    public string HairColor { get; set; } = null!;
    public string SkinColor { get; set; } = null!;
    public string EyeColor { get; set; } = null!;
    public string BirthYear { get; set; } = null!;
    public int PlanetCode { get; set; }
    public int MovieCode { get; set; }
    public Planet Planet { get; set; } = null!;
    public IList<Movie> Movies { get; set; } = [];

    private People(int code, string name, string height, string weight, string hairColor, string skinColor, string eyeColor, string birthYear, int planetCode, int movieCode) : this()
    {
        Code = code;
        Name = name;
        Height = height;
        Weight = weight;
        HairColor = hairColor;
        SkinColor = skinColor;
        EyeColor = eyeColor;
        BirthYear = birthYear;
        PlanetCode = planetCode;
        MovieCode = movieCode;
    }
    
    public static IList<People> ToModel(IList<PeopleResultApi>? people) => FromApiToModel(people);
    
    private static IList<People> FromApiToModel(IList<PeopleResultApi>? peoples)
    {
        if (peoples is null) return new List<People>();

        return (from people in peoples 
                from movie in people.Films 
                select new People(
                    code: Parsers.ExtractCodeFromUrl(people.Url), 
                    name: people.Name, 
                    height: people.Height, 
                    weight: people.Mass, 
                    hairColor: people.HairColor, 
                    skinColor: people.SkinColor, 
                    eyeColor: people.EyeColor, 
                    birthYear: people.BirthYear, 
                    planetCode: Parsers.ExtractCodeFromUrl(people.Homeworld), 
                    movieCode: Parsers.ExtractCodeFromUrl(movie)))
                .ToList();
    }
}