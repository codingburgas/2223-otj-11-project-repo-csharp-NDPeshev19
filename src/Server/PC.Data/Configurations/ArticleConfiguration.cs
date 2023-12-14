using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PC.Data.Models;

namespace PC.Data.Configurations;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .HasMany(a => a.ArticlePlacementStudents)
            .WithOne(aps => aps.Article)
            .HasForeignKey(aps => aps.ArticleId)
            // TODO: when deleting an article delete the row in the bridge table
            // could be with cascade but idfk what cascade does so check it
            // for now this is good enough
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
