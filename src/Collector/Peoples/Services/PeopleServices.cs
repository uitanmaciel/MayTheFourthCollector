using Collector.Peoples.Commands;
using Collector.Peoples.Interfaces;
using Collector.Peoples.Queries;
using MediatR;

namespace Collector.Peoples.Services;

public class PeopleServices(IMediator mediator) : IPeopleServices
{
    public async Task<IList<People>> GetPeoplesAsync(CancellationToken cancellationToken = default)
    {
        var peoples = await mediator.Send(new GetPeoplesQuery());
        return People.ToModel(peoples!);
    }

    public async Task CreatePeopleAsync(CancellationToken cancellationToken = default)
    {
        var peoples = await GetPeoplesAsync(cancellationToken);
        await mediator.Send(new CreatePeopleCommand(peoples), cancellationToken);
    }
}