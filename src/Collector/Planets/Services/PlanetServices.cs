using Collector.Planets.Commands;
using Collector.Planets.Interfaces;
using Collector.Planets.Queries;
using MediatR;

namespace Collector.Planets.Services;

public class PlanetServices(IMediator mediator) : IPlanetServices
{
    public async Task<IList<Planet>?> GetPlanetsAsync(CancellationToken cancellationToken = default)
    {
        var planets = await mediator.Send(new GetPlanetsQuery(), cancellationToken);
        return Planet.ToModel(planets!);
    }

    public async Task CreatePlanetsAsync(CancellationToken cancellationToken = default)
    {
        var planets = await GetPlanetsAsync(cancellationToken);
        await mediator.Send(new CreatePlanetsCommand(planets!), cancellationToken);
    }
}