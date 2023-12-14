using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PC.Data.Models.Accounts;

namespace PC.Data.Configurations.Accounts;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder
            .HasMany(s => s.ArticlePlacementStudents)
            .WithOne(aps => aps.Student)
            .HasForeignKey(aps => aps.StudentId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
