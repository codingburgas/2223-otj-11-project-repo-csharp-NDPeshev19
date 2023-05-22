using BMS.Data.Models.Misc;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BMS.Data.ExtensionMethods;

public static class ModelBuilderExtension
{
    public static EntityTypeBuilder<BloodType> Seed(this EntityTypeBuilder<BloodType> builder)
    {
        int id = 1;

        foreach (BloodGroup group in Enum.GetValues(typeof(BloodGroup)))
        {
            foreach (RhFactor factor in Enum.GetValues(typeof(RhFactor)))
            {
                builder.HasData(new BloodType
                {
                    Id = id,
                    Group = group,
                    RhFactor = factor,
                });

                id++;
            }
        }

        return builder;
    }
}
