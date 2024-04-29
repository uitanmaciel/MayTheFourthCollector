namespace Collector.Peoples.Interfaces;

public interface IPeopleServices
{
    Task<IList<People>> GetPeoplesAsync(CancellationToken cancellationToken = default);
    Task CreatePeopleAsync(CancellationToken cancellationToken = default);
}