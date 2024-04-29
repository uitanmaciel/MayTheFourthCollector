using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collector.Peoples.Repository;

public class PeopleMap : IEntityTypeConfiguration<People>
{
    public void Configure(EntityTypeBuilder<People> builder)
    {
        builder.ToTable("Peoples");
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.Code).IsUnique(false);
        builder.Property(p => p.Code)
            .HasColumnType("integer(10)")
            .IsRequired();
        builder.Property(p => p.Name).HasColumnType("nvarchar(100)");
        builder.Property(p => p.Height).HasColumnType("nvarchar(30)");
        builder.Property(p => p.Weight).HasColumnType("nvarchar(30)");
        builder.Property(p => p.HairColor).HasColumnType("nvarchar(30)");
        builder.Property(p => p.SkinColor).HasColumnType("nvarchar(30)");
        builder.Property(p => p.EyeColor).HasColumnType("nvarchar(30)");
        builder.Property(p => p.BirthYear).HasColumnType("nvarchar(30)");
        builder.Property(p => p.PlanetCode).HasColumnType("integer(10)");
        builder.Property(p => p.MovieCode).HasColumnType("integer(10)");
        builder.HasOne(p => p.Planet)
            .WithMany(p => p.Characters)
            .HasForeignKey(p => p.PlanetCode);
        builder.HasMany(p => p.Movies)
            .WithMany(m => m.Characters);
    }
}