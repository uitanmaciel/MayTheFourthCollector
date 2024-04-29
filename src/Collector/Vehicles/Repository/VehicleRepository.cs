using Collector.Data;
using Collector.Vehicles.Interfaces;

namespace Collector.Vehicles.Repository;

public class VehicleRepository(CollectorContext context) : IVehicleRepository, IAsyncDisposable
{
    public async Task InsertManyAsync(IList<Vehicle> vehicles, CancellationToken cancellationToken = default)
    {
        await context.Vehicles.AddRangeAsync(vehicles, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async ValueTask DisposeAsync() => await context.DisposeAsync();
}