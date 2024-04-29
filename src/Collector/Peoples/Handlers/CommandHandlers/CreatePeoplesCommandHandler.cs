using Collector.Peoples.Commands;
using Collector.Peoples.Interfaces;
using MediatR;

namespace Collector.Peoples.Handlers.CommandHandlers;

public class CreatePeoplesCommandHandler(IPeopleRepository peopleRepository) : IRequestHandler<CreatePeopleCommand, bool>
{
    public async Task<bool> Handle(CreatePeopleCommand request, CancellationToken cancellationToken)
    {
        await peopleRepository.InsertManyAsync(request.Peoples, cancellationToken);
        return true;
    }
}