namespace Collector.Planets.Interfaces;

public interface IPlanetRepository
{
    Task InsertManyAsync(IList<Planet> planets, CancellationToken cancellationToken = default);
}