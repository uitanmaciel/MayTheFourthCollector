using Collector.Movies.Commands;
using Collector.Movies.Interfaces;
using MediatR;

namespace Collector.Movies.Handlers.CommandHandlers;

public class CreateMoviesCommandHandler(IMovieRepository movieRepository) : IRequestHandler<CreateMoviesCommand, bool>
{
    public Task<bool> Handle(CreateMoviesCommand request, CancellationToken cancellationToken)
    {
        movieRepository.InsertManyAsync(request.Movies, cancellationToken);
        return Task.FromResult(true);
    }
}