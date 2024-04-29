using Collector.Movies;
using Collector.Peoples;
using Collector.Planets;
using Collector.Starships;
using Collector.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace Collector.Data;

public class CollectorContext(DbContextOptions<CollectorContext> optionsBuilderOptions) : DbContext(optionsBuilderOptions)
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<People> Peoples { get; set; }
    public DbSet<Planet> Planets { get; set; }
    public DbSet<Starship> Starships { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=C:/Users/Uitan Maciel/Documents/Projects/MayTheFourthCollector/src/Collector/maythefourth.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(CollectorContext).Assembly);
}