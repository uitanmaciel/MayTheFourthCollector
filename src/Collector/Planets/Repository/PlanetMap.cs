using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collector.Planets.Repository;

public class PlanetMap : IEntityTypeConfiguration<Planet>
{
    public void Configure(EntityTypeBuilder<Planet> builder)
    {
        builder.ToTable("Planets");
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.Code).IsUnique(false);
        builder.Property(p => p.Code)
            .HasColumnType("integer(10)")
            .IsRequired();
        builder.Property(p => p.Name).HasColumnType("nvarchar(100)");
        builder.Property(p => p.Diameter).HasColumnType("nvarchar(30)");
        builder.Property(p => p.RotationPeriod).HasColumnType("nvarchar(30)");
        builder.Property(p => p.OrbitalPeriod).HasColumnType("nvarchar(30)");
        builder.Property(p => p.Gravity).HasColumnType("nvarchar(30)");
        builder.Property(p => p.Population).HasColumnType("nvarchar(30)");
        builder.Property(p => p.Climate).HasColumnType("nvarchar(30)");
        builder.Property(p => p.Terrain).HasColumnType("nvarchar(30)");
        builder.Property(p => p.SurfaceWater).HasColumnType("nvarchar(30)");
        builder.Property(p => p.CharacterCode).HasColumnType("integer(10)");
        builder.Property(p => p.MovieCode).HasColumnType("integer(10)");
        builder.HasMany(p => p.Characters)
            .WithOne(p => p.Planet)
            .HasForeignKey(p => p.PlanetCode);
        builder.HasMany(p => p.Movies)
            .WithMany(m => m.Planets);
    }
}