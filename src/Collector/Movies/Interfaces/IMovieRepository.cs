namespace Collector.Movies.Interfaces;

public interface IMovieRepository
{
    Task InsertManyAsync(IList<Movie> movies, CancellationToken cancellationToken = default);
}