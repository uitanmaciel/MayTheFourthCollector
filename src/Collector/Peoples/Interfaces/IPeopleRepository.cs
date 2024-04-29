namespace Collector.Peoples.Interfaces;

public interface IPeopleRepository
{
    Task InsertManyAsync(IList<People> peoples, CancellationToken cancellationToken = default);
}