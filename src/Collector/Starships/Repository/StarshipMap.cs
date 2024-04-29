using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collector.Starships.Repository;

public class StarshipMap : IEntityTypeConfiguration<Starship>
{
    public void Configure(EntityTypeBuilder<Starship> builder)
    {
        builder.ToTable("Starships");
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.Code).IsUnique(false);
        builder.Property(p => p.Code)
            .HasColumnType("integer(10)")
            .IsRequired();
        builder.Property(p => p.Name).HasColumnType("nvarchar(100)");
        builder.Property(p => p.Model).HasColumnType("nvarchar(100)");
        builder.Property(p => p.Manufacturer).HasColumnType("nvarchar(100)");
        builder.Property(p => p.CostInCredits).HasColumnType("nvarchar(30)");
        builder.Property(p => p.Length).HasColumnType("nvarchar(30)");
        builder.Property(p => p.MaxSpeed).HasColumnType("nvarchar(30)");
        builder.Property(p => p.Crew).HasColumnType("nvarchar(30)");
        builder.Property(p => p.Passengers).HasColumnType("nvarchar(30)");
        builder.Property(p => p.CargoCapacity).HasColumnType("nvarchar(30)");
        builder.Property(p => p.HyperdriveRating).HasColumnType("nvarchar(30)");
        builder.Property(p => p.Mglt).HasColumnType("nvarchar(30)");
        builder.Property(p => p.Consumables).HasColumnType("nvarchar(30)");
        builder.Property(p => p.Class).HasColumnType("nvarchar(30)");
        builder.Property(p => p.MovieCode).HasColumnType("integer(10)");
        builder.HasMany(p => p.Movies)
            .WithMany(m => m.Starships);
    }
}