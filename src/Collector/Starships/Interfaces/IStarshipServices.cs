namespace Collector.Starships.Interfaces;

public interface IStarshipServices
{
    Task<IList<Starship>> GetStarshipsAsync(CancellationToken cancellationToken = default);
    Task CreateStarshipAsync(CancellationToken cancellationToken = default);
}