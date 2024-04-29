namespace Collector.Movies.Interfaces;

public interface IMovieServices
{
    Task<IList<Movie>> GetMoviesAsync(CancellationToken cancellationToken = default);
    Task CreateMoviesAsync(CancellationToken cancellationToken = default);
}