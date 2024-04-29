using Collector.Vehicles.Commands;
using Collector.Vehicles.Interfaces;
using MediatR;

namespace Collector.Vehicles.Handlers.CommandHandlers;

public class CreateVehiclesCommandHandler(IVehicleRepository vehicleRepository) : IRequestHandler<CreateVehiclesCommand, bool>
{
    public async Task<bool> Handle(CreateVehiclesCommand request, CancellationToken cancellationToken = default)
    {
        await vehicleRepository.InsertManyAsync(request.Vehicles, cancellationToken);
        return true;
    }
}