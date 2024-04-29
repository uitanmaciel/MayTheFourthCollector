using Collector.Starships.Commands;
using Collector.Starships.Interfaces;
using MediatR;

namespace Collector.Starships.Handlers.CommandHandlers;

public class CreateStarshipsCommandHandler(IStarshipRepository starshipRepository) : IRequestHandler<CreateStashipsCommand, bool>
{
    public async Task<bool> Handle(CreateStashipsCommand request, CancellationToken cancellationToken = default)
    {
        await starshipRepository.InsertManyAsync(request.Starships, cancellationToken);
        return true;
    }
}