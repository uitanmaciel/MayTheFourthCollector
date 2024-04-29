using Collector.ExternalModels.Starship;
using MediatR;

namespace Collector.Starships.Queries;

public record GetStarshipsQuery() : IRequest<IList<StarshipResultApi>>;