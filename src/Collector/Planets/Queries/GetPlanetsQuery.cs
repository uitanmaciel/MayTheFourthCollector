using Collector.ExternalModels.Planet;
using MediatR;

namespace Collector.Planets.Queries;

public record GetPlanetsQuery() : IRequest<IList<PlanetResultApi>>;