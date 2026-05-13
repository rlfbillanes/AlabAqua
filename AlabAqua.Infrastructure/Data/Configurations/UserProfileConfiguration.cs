using AlabAqua.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.ToTable("UserProfiles");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.UserId)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.DisplayName)
            .HasMaxLength(255);

        builder.Property(p => p.Location)
            .HasMaxLength(255);

        builder.Property(p => p.AvatarUrl)
            .HasMaxLength(500);

        builder.Property(p => p.DefaultContactEmail)
            .HasMaxLength(255);

        builder.Property(p => p.DefaultContactPhone)
            .HasMaxLength(50);

        builder.Property(p => p.FacebookLink)
            .HasMaxLength(255);

        builder.Property(p => p.InstagramLink)
            .HasMaxLength(255);

        // ⭐ FIXED: MySQL-safe CreatedAt
        builder.Property(p => p.CreatedAt)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        // ⭐ FIXED: MySQL-safe UpdatedAt
        builder.Property(p => p.UpdatedAt)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}
