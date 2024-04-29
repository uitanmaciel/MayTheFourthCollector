using Collector.Data;
using Collector.Starships.Interfaces;

namespace Collector.Starships.Repository;

public class StarshipRepository(CollectorContext context) : IStarshipRepository, IAsyncDisposable
{
    public async Task InsertManyAsync(IList<Starship> starships, CancellationToken cancellationToken = default)
    {
        await context.Starships.AddRangeAsync(starships, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async ValueTask DisposeAsync() => await context.DisposeAsync();
}