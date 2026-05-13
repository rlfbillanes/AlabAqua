using AlabAqua.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.UserId)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.Status)
            .HasMaxLength(50)
            .HasDefaultValue("Pending");

        builder.Property(p => p.PriceText).HasMaxLength(255);
        builder.Property(p => p.ContactEmail).HasMaxLength(255);
        builder.Property(p => p.ContactPhone).HasMaxLength(50);

        // ⭐ FIXED: MySQL-safe CreatedAt
        builder.Property(p => p.CreatedAt)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        // ⭐ FIXED: MySQL-safe UpdatedAt (no ValueGeneratedOnAddOrUpdate)
        builder.Property(p => p.UpdatedAt)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(p => p.User)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.UserId);
    }
}
