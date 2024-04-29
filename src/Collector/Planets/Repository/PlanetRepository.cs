using Collector.Data;
using Collector.Planets.Interfaces;

namespace Collector.Planets.Repository;

public class PlanetRepository(CollectorContext context) : IPlanetRepository, IAsyncDisposable
{
    public async Task InsertManyAsync(IList<Planet> planets, CancellationToken cancellationToken = default)
    {
        await context.Planets.AddRangeAsync(planets, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async ValueTask DisposeAsync() => await context.DisposeAsync();
}