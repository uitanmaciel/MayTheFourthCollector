using System.Text.Json;
using Collector.ExternalModels.Vehicle;
using Collector.Helpers;
using Collector.Vehicles.Queries;
using MediatR;

namespace Collector.Vehicles.Handlers.QueryHandlers;

public class GetVehiclesQueryHandler : IRequestHandler<GetVehiclesQuery, IList<VehicleResultApi>>
{
    public async Task<IList<VehicleResultApi>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken = default)
    {
        var httpClient = new HttpClient();
        var tasks = new List<Task<string>>();
        for(var i = 1; i <= 4; i++)
            tasks.Add(httpClient.GetStringAsync(new Uri($"{UrlBaseApi.GetUrlBase()}/vehicles/?page={i}&format=json"), cancellationToken));
        
        var response = await Task.WhenAll(tasks);
        var responseList = new List<VehicleResponse>();
        foreach(var res in response)
            responseList.Add(JsonSerializer.Deserialize<VehicleResponse>(res)!);
        var vehicleList = new List<VehicleResultApi>();
        foreach(var responseItem in responseList)
            vehicleList.AddRange(responseItem.Results);
        
        return vehicleList;
    }
}