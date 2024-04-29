using System.Text.Json;
using Collector.ExternalModels.Movie;
using Collector.Helpers;
using Collector.Movies.Queries;
using MediatR;

namespace Collector.Movies.Handlers.QueryHandlers;

public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IList<MovieResultApi?>>
{
    public async Task<IList<MovieResultApi?>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        var httpClient = new HttpClient();
        var uri = new Uri($"{UrlBaseApi.GetUrlBase()}/films/?page=1&format=json");
        var response = await httpClient.GetStringAsync(uri, cancellationToken);
        var result = JsonSerializer.Deserialize<MovieResponse>(response);
        var movies = new List<MovieResultApi>();
        if(result is not null)
            movies.AddRange(result.Results);
        return movies!;
    }
}