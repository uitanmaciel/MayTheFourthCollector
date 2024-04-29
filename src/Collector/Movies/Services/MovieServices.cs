using Collector.Movies.Commands;
using Collector.Movies.Interfaces;
using Collector.Movies.Queries;
using MediatR;

namespace Collector.Movies.Services;

public class MovieServices(IMediator mediator) : IMovieServices
{
    public async Task<IList<Movie>> GetMoviesAsync(CancellationToken cancellationToken = default)
    {
        var movies = await mediator.Send(new GetMoviesQuery());
        return Movie.ToModel(movies!);
    }

    public async Task CreateMoviesAsync(CancellationToken cancellationToken = default)
    {
        var movies = await GetMoviesAsync();
        await mediator.Send(new CreateMoviesCommand(movies));
    }
}