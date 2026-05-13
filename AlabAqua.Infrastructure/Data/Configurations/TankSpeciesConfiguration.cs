using AlabAqua.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TankSpeciesConfiguration : IEntityTypeConfiguration<TankSpecies>
{
    public void Configure(EntityTypeBuilder<TankSpecies> builder)
    {
        builder.ToTable("TankSpecies");

        builder.HasKey(x => new { x.TankId, x.SpeciesId });

        builder.HasOne(x => x.Tank)
            .WithMany(t => t.TankSpecies)
            .HasForeignKey(x => x.TankId);

        builder.HasOne(x => x.Species)
            .WithMany(s => s.TankSpecies)
            .HasForeignKey(x => x.SpeciesId);
    }
}
