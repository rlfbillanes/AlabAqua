using AlabAqua.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ModerationLogConfiguration : IEntityTypeConfiguration<ModerationLog>
{
    public void Configure(EntityTypeBuilder<ModerationLog> builder)
    {
        builder.ToTable("ModerationLogs");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.ContentType)
            .HasMaxLength(50);

        builder.Property(m => m.Action)
            .HasMaxLength(50);

        // ⭐ MySQL-safe timestamp (no datetime(6), no ValueGeneratedOnAddOrUpdate)
        builder.Property(m => m.CreatedAt)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(m => m.Moderator)
            .WithMany(u => u.ModerationLogs)
            .HasForeignKey(m => m.ModeratorId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
