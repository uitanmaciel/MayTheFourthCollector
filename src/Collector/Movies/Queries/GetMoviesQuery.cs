using Collector.ExternalModels.Movie;
using MediatR;

namespace Collector.Movies.Queries;

public record GetMoviesQuery() : IRequest<IList<MovieResultApi>>;