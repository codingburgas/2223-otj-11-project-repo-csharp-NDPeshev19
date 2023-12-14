using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PC.Data.Models;

namespace PC.Data.Configurations;

public class PlacementConfiguration : IEntityTypeConfiguration<Placement>
{
    public void Configure(EntityTypeBuilder<Placement> builder)
    {
        builder
            .HasKey(p => p.Title);

        builder
            .HasMany(p => p.ArticlePlacementStudents)
            .WithOne(aps => aps.Placement)
            .HasForeignKey(aps => aps.PlacementId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
