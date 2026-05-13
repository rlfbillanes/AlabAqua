using AlabAqua.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PostSpeciesConfiguration : IEntityTypeConfiguration<PostSpecies>
{
    public void Configure(EntityTypeBuilder<PostSpecies> builder)
    {
        builder.ToTable("PostSpecies");

        builder.HasKey(x => new { x.PostId, x.SpeciesId });

        builder.HasOne(x => x.Post)
            .WithMany(p => p.PostSpecies)
            .HasForeignKey(x => x.PostId);

        builder.HasOne(x => x.Species)
            .WithMany(s => s.PostSpecies)
            .HasForeignKey(x => x.SpeciesId);
    }
}
