using Collector.Vehicles.Commands;
using Collector.Vehicles.Interfaces;
using Collector.Vehicles.Queries;
using MediatR;

namespace Collector.Vehicles.Services;

public class VehicleServices(IMediator mediator) : IVehicleServices
{
    public async Task<IList<Vehicle>> GetVehiclesAsync(CancellationToken cancellationToken = default)
    {
        var vehicles = await mediator.Send(new GetVehiclesQuery(), cancellationToken);
        return Vehicle.ToModel(vehicles);
    }

    public async Task CreateVehicleAsync(CancellationToken cancellationToken = default)
    {
        var vehicles = await GetVehiclesAsync(cancellationToken);
        await mediator.Send(new CreateVehiclesCommand(vehicles), cancellationToken);
    }
}