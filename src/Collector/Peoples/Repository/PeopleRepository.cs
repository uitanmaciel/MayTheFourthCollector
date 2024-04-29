using Collector.Data;
using Collector.Peoples.Interfaces;

namespace Collector.Peoples.Repository;

public class PeopleRepository(CollectorContext context) : IPeopleRepository, IAsyncDisposable
{
    public async Task InsertManyAsync(IList<People> peoples, CancellationToken cancellationToken = default)
    {
        await context.Peoples.AddRangeAsync(peoples, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public async ValueTask DisposeAsync() => await context.DisposeAsync();
}