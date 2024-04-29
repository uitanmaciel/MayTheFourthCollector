using Collector.Starships.Commands;
using Collector.Starships.Interfaces;
using Collector.Starships.Queries;
using MediatR;

namespace Collector.Starships.Services;

public class StarshipServices(IMediator mediator) : IStarshipServices
{
    public async Task<IList<Starship>> GetStarshipsAsync(CancellationToken cancellationToken = default)
    {
        var starships = await mediator.Send(new GetStarshipsQuery(), cancellationToken);
        return Starship.ToModel(starships!);
    }

    public async Task CreateStarshipAsync(CancellationToken cancellationToken = default)
    {
        var starships = await GetStarshipsAsync(cancellationToken);
        await mediator.Send(new CreateStashipsCommand(starships), cancellationToken);
    }
}