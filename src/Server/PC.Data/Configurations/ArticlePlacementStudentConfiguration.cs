using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PC.Data.Models;

namespace PC.Data.Configurations;

public class ArticlePlacementStudentConfiguration : IEntityTypeConfiguration<ArticlePlacementStudent>
{
    public void Configure(EntityTypeBuilder<ArticlePlacementStudent> builder)
    {
        builder
            .HasKey(aps => new 
            { 
                aps.ArticleId, 
                aps.PlacementId, 
                aps.StudentId 
            });
    }
}
