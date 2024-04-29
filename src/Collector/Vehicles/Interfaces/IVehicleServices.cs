namespace Collector.Vehicles.Interfaces;

public interface IVehicleServices
{
    Task<IList<Vehicle>> GetVehiclesAsync(CancellationToken cancellationToken = default);
    Task CreateVehicleAsync(CancellationToken cancellationToken = default);
}