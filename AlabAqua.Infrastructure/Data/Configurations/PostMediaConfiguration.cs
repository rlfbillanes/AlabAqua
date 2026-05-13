using AlabAqua.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PostMediaConfiguration : IEntityTypeConfiguration<PostMedia>
{
    public void Configure(EntityTypeBuilder<PostMedia> builder)
    {
        builder.ToTable("PostMedia");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.MediaUrl)
            .HasMaxLength(500);

        builder.Property(m => m.MediaType)
            .HasMaxLength(50);

        builder.Property(m => m.ThumbnailUrl)
            .HasMaxLength(500);

        builder.Property(m => m.MediaData)
            .HasColumnType("LONGBLOB");

        // ⭐ FIXED: MySQL-safe timestamp
        builder.Property(m => m.CreatedAt)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(m => m.Post)
            .WithMany(p => p.Media)
            .HasForeignKey(m => m.PostId);
    }
}
