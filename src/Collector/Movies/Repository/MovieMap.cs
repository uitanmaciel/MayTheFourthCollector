using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collector.Movies.Repository;

public class MovieMap : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");
        builder.HasKey(m => m.Id);
        builder.HasIndex(m => m.Code).IsUnique(false);
        builder.Property(m => m.Code)
            .HasColumnType("integer(10)")
            .IsRequired();
        builder.Property(m => m.Title).HasColumnType("nvarchar(100)");
        builder.Property(m => m.Episode).HasColumnType("integer(10)");
        builder.Property(m => m.OpeningCrawl).HasColumnType("nvarchar(255)");
        builder.Property(m => m.Director).HasColumnType("nvarchar(50)");
        builder.Property(m => m.Producer).HasColumnType("nvarchar(50)");
        builder.Property(m => m.ReleaseDate).HasColumnType("nvarchar(11)");
        builder.Property(m => m.CharacterCode).HasColumnType("integer(10)");
        builder.Property(m => m.PlanetCode).HasColumnType("integer(10)");
        builder.Property(m => m.VehicleCode).HasColumnType("integer(10)");
        builder.Property(m => m.StarshipCode).HasColumnType("integer(10)");
        builder.HasMany(m => m.Characters)
            .WithMany(c => c.Movies);
        builder.HasMany(m => m.Planets)
            .WithMany(p => p.Movies);
        builder.HasMany(m => m.Vehicles)
            .WithMany(v => v.Movies);
        builder.HasMany(m => m.Starships)
            .WithMany(s => s.Movies);
    }
}