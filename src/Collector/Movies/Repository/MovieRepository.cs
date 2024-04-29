using Collector.Data;
using Collector.Movies.Interfaces;

namespace Collector.Movies.Repository;

public class MovieRepository(CollectorContext context) : IMovieRepository, IAsyncDisposable
{
    public async Task InsertManyAsync(IList<Movie> movies, CancellationToken cancellationToken = default)
    {
        await context.Movies.AddRangeAsync(movies, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async ValueTask DisposeAsync() => await context.DisposeAsync();
}