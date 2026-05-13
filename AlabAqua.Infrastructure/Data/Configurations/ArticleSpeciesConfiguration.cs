using AlabAqua.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ArticleSpeciesConfiguration : IEntityTypeConfiguration<ArticleSpecies>
{
    public void Configure(EntityTypeBuilder<ArticleSpecies> builder)
    {
        builder.ToTable("ArticleSpecies");

        builder.HasKey(x => new { x.ArticleId, x.SpeciesId });

        builder.HasOne(x => x.Article)
            .WithMany(a => a.ArticleSpecies)
            .HasForeignKey(x => x.ArticleId);

        builder.HasOne(x => x.Species)
            .WithMany(s => s.ArticleSpecies)
            .HasForeignKey(x => x.SpeciesId);
    }
}
