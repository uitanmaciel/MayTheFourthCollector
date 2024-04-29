using MediatR;

namespace Collector.Vehicles.Commands;

public record CreateVehiclesCommand(IList<Vehicle> Vehicles) : IRequest<bool>;