using MediatR;

namespace Collector.Starships.Commands;

public record CreateStashipsCommand(IList<Starship> Starships) : IRequest<bool>;