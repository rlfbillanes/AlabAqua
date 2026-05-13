using AlabAqua.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("Articles");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.AuthorId)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(a => a.Title)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(a => a.Slug)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(a => a.Content)
            .HasColumnType("LONGTEXT");

        builder.Property(a => a.Status)
            .HasMaxLength(50)
            .HasDefaultValue("Pending");

        // ⭐ FIXED: MySQL-safe timestamp
        builder.Property(a => a.CreatedAt)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        // ⭐ FIXED: MySQL-safe updated timestamp
        builder.Property(a => a.UpdatedAt)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(a => a.Author)
            .WithMany(u => u.Articles)
            .HasForeignKey(a => a.AuthorId);
    }
}
