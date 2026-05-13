using AlabAqua.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TankConfiguration : IEntityTypeConfiguration<Tank>
{
    public void Configure(EntityTypeBuilder<Tank> builder)
    {
        builder.ToTable("Tanks");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.UserId)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(t => t.Name)
            .HasMaxLength(255);

        builder.Property(t => t.Filtration)
            .HasMaxLength(255);

        builder.Property(t => t.Lighting)
            .HasMaxLength(255);

        builder.Property(t => t.Substrate)
            .HasMaxLength(255);

        // ⭐ FIXED: MySQL-safe timestamp
        builder.Property(t => t.CreatedAt)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(t => t.User)
            .WithMany()
            .HasForeignKey(t => t.UserId);
    }
}
