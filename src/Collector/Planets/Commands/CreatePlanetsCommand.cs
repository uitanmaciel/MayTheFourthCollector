using MediatR;

namespace Collector.Planets.Commands;

public record CreatePlanetsCommand(IList<Planet> Planets) : IRequest<bool>;