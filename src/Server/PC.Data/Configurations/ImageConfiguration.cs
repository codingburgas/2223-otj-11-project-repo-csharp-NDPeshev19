using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PC.Data.Models;

namespace PC.Data.Configurations;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder
            .HasKey(i => i.ImageUrl);

        builder
            .HasOne(i => i.Article)
            .WithMany(a => a.Images)
            .HasForeignKey(i => i.ArticleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
