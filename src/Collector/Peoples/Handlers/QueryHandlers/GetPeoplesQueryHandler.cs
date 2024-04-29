using System.Text.Json;
using Collector.ExternalModels.Movie;
using Collector.ExternalModels.People;
using Collector.Helpers;
using Collector.Peoples.Queries;
using MediatR;

namespace Collector.Peoples.Handlers.QueryHandlers;

public class GetPeoplesQueryHandler : IRequestHandler<GetPeoplesQuery, IList<PeopleResultApi>>
{
    public async Task<IList<PeopleResultApi>> Handle(GetPeoplesQuery request, CancellationToken cancellationToken = default)
    {
        var httpClient = new HttpClient();
        var tasks = new List<Task<string>>();
        for(var i = 1; i <= 9; i++)
            tasks.Add(httpClient.GetStringAsync(new Uri($"{UrlBaseApi.GetUrlBase()}/people/?page={i}&format=json"), cancellationToken));
        
        var response = await Task.WhenAll(tasks);
        var responseList = new List<PeopleResponse>();
        foreach(var res in response)
            responseList.Add(JsonSerializer.Deserialize<PeopleResponse>(res)!);
        
        var peopleList = new List<PeopleResultApi>();
        foreach (var responseItem in responseList) 
            peopleList.AddRange(responseItem.Results);

        return peopleList!;
    }
}