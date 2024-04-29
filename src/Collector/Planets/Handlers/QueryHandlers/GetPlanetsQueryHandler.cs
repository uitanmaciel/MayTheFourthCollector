using System.Text.Json;
using Collector.ExternalModels.Planet;
using Collector.Helpers;
using Collector.Planets.Queries;
using MediatR;

namespace Collector.Planets.Handlers.QueryHandlers;

public class GetPlanetsQueryHandler : IRequestHandler<GetPlanetsQuery, IList<PlanetResultApi>>
{
    public async Task<IList<PlanetResultApi>> Handle(GetPlanetsQuery request, CancellationToken cancellationToken = default)
    {
        var httpClient = new HttpClient();
        var tasks = new List<Task<string>>();
        for(var i = 1; i <= 7; i++)
            tasks.Add(httpClient.GetStringAsync(new Uri($"{UrlBaseApi.GetUrlBase()}/planets/?page={i}&format=json"), cancellationToken));
        
        var response = await Task.WhenAll(tasks);
        var responseList = new List<PlanetResponse>();
        foreach(var res in response)
            responseList.Add(JsonSerializer.Deserialize<PlanetResponse>(res)!);
        
        var planetList = new List<PlanetResultApi>();
        foreach(var responseItem in responseList)
            planetList.AddRange(responseItem.Results);
        
        return planetList;
    }
}