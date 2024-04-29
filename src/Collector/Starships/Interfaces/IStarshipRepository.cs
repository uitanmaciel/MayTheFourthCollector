namespace Collector.Starships.Interfaces;

public interface IStarshipRepository
{
    Task InsertManyAsync(IList<Starship> starships, CancellationToken cancellationToken = default);
}