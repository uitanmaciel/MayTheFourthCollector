namespace Collector.Vehicles.Interfaces;

public interface IVehicleRepository
{
    Task InsertManyAsync(IList<Vehicle> vehicles, CancellationToken cancellationToken = default);
}