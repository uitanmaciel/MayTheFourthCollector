using Collector.ExternalModels.Vehicle;
using MediatR;

namespace Collector.Vehicles.Queries;

public record GetVehiclesQuery() : IRequest<IList<VehicleResultApi>>;