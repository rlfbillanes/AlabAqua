using AlabAqua.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlabAqua.Infrastructure.Data.Configurations
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("UserProfiles");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.DisplayName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.AvatarUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.Location)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Bio)
                .HasMaxLength(500);

            builder.Property(p => p.ExperienceLevel)
                .HasMaxLength(50);

            builder.Property(p => p.FavoriteSpecies)
                .HasMaxLength(100);

            builder.Property(p => p.AquariumCount);

            builder.Property(p => p.JoinedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
