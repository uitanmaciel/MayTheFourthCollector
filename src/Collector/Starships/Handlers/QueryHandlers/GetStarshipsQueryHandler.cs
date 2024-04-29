using System.Text.Json;
using Collector.ExternalModels.Starship;
using Collector.Helpers;
using Collector.Starships.Queries;
using MediatR;

namespace Collector.Starships.Handlers.QueryHandlers;

public class GetStarshipsQueryHandler : IRequestHandler<GetStarshipsQuery, IList<StarshipResultApi>>
{
    public async Task<IList<StarshipResultApi>> Handle(GetStarshipsQuery request, CancellationToken cancellationToken = default)
    {
        var httpClient = new HttpClient();
        var tasks = new List<Task<string>>();
        for(var i = 1; i <= 4; i++)
            tasks.Add(httpClient.GetStringAsync(new Uri($"{UrlBaseApi.GetUrlBase()}/starships/?page={i}&format=json"), cancellationToken));
        
        var response = await Task.WhenAll(tasks);
        var responseList = new List<StarshipResponse>();
        foreach(var res in response)
            responseList.Add(JsonSerializer.Deserialize<StarshipResponse>(res)!);
        var starshipList = new List<StarshipResultApi>();
        foreach(var responseItem in responseList)
            starshipList.AddRange(responseItem.Results);
        
        return starshipList;
    }
}