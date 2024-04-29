using Collector.ExternalModels.Movie;
using Collector.ExternalModels.People;
using MediatR;

namespace Collector.Peoples.Queries;

public record GetPeoplesQuery() : IRequest<IList<PeopleResultApi>>;