using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PC.Data.Models.Accounts;

namespace PC.Data.Configurations.Accounts;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasMany(u => u.ArticlesCreated)
            .WithOne(a => a.CreatedBy)
            .HasForeignKey(a => a.CreatedById)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder
            .HasMany(u => u.ArticlesEdited)
            .WithOne(a => a.LastEditedBy)
            .HasForeignKey(a => a.LastEditedById)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
