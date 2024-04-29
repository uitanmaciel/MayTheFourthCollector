using MediatR;

namespace Collector.Movies.Commands;

public record CreateMoviesCommand(IList<Movie> Movies) : IRequest<bool>;