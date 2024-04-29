using Collector.Planets.Commands;
using Collector.Planets.Interfaces;
using MediatR;

namespace Collector.Planets.Handlers.CommandHandlers;

public class CreatePlanetsCommandHandler(IPlanetRepository planetRepository) : IRequestHandler<CreatePlanetsCommand, bool>
{
    public async Task<bool> Handle(CreatePlanetsCommand request, CancellationToken cancellationToken = default)
    {
        await planetRepository.InsertManyAsync(request.Planets, cancellationToken);
        return true;
    }
}