using AlabAqua.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SpeciesMediaConfiguration : IEntityTypeConfiguration<SpeciesMedia>
{
    public void Configure(EntityTypeBuilder<SpeciesMedia> builder)
    {
        builder.ToTable("SpeciesMedia");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.MediaUrl)
            .HasMaxLength(500);

        builder.Property(m => m.MediaType)
            .HasMaxLength(50);

        builder.Property(m => m.MediaData)
            .HasColumnType("LONGBLOB");

        // ⭐ FIXED: MySQL-safe timestamp
        builder.Property(m => m.CreatedAt)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(m => m.Species)
            .WithMany(s => s.Media)
            .HasForeignKey(m => m.SpeciesId);

        builder.HasOne(m => m.Uploader)
            .WithMany(u => u.UploadedSpeciesMedia)
            .HasForeignKey(m => m.UploadedBy)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
