namespace Collector.Planets.Interfaces;

public interface IPlanetServices
{
    Task<IList<Planet>?> GetPlanetsAsync(CancellationToken cancellationToken = default);
    Task CreatePlanetsAsync(CancellationToken cancellationToken = default);
}