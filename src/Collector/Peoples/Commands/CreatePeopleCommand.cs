using MediatR;

namespace Collector.Peoples.Commands;

public record CreatePeopleCommand(IList<People> Peoples) : IRequest<bool>;