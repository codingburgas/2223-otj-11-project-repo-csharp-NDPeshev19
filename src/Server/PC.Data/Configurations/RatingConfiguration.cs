using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC.Data.Models;

namespace PC.Data.Configurations;

public class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder
            .HasKey(r => r.Id);

        builder
            .HasOne(r => r.Article)
            .WithMany(a => a.Ratings)
            .HasForeignKey(r => r.ArticleId);

        builder
            .HasOne(r => r.User)
            .WithMany(u => u.Ratings)
            .HasForeignKey(r => r.UserId);
    }
}