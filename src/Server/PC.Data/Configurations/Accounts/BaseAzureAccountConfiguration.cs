using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PC.Data.Models.Accounts;

namespace PC.Data.Configurations.Accounts;

public class BaseAzureAccountConfiguration : IEntityTypeConfiguration<BaseAzureAccount>
{
    public void Configure(EntityTypeBuilder<BaseAzureAccount> builder)
    {
        builder
            .HasKey(x => x.Id);
    }
}
