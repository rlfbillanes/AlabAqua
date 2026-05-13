using AlabAqua.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AIContentCheckConfiguration : IEntityTypeConfiguration<AIContentCheck>
{
    public void Configure(EntityTypeBuilder<AIContentCheck> builder)
    {
        builder.ToTable("AIContentChecks");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.ContentType).HasMaxLength(50);

        builder.Property(a => a.RawResultJson)
            .HasColumnType("LONGTEXT");

        builder.Property(a => a.CreatedAt)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}
