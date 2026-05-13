using AlabAqua.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
{
    public void Configure(EntityTypeBuilder<Species> builder)
    {
        builder.ToTable("Species");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.ScientificName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(s => s.CommonName)
            .HasMaxLength(255);

        builder.Property(s => s.WaterType)
            .HasMaxLength(50);

        builder.Property(s => s.Difficulty)
            .HasMaxLength(50);

        builder.Property(s => s.Temperament)
            .HasMaxLength(255);

        builder.Property(s => s.CareLevel)
            .HasMaxLength(255);

        builder.Property(s => s.Description)
            .HasColumnType("LONGTEXT");

        // ⭐ MySQL-safe CreatedAt
        builder.Property(s => s.CreatedAt)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        // ⭐ MySQL-safe UpdatedAt
        builder.Property(s => s.UpdatedAt)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}
