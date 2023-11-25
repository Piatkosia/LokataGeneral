using Lokata.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lokata.DataAccess.TypeConfigurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> entity)
        {
            entity.ToTable("Instructor");
            entity.HasQueryFilter(t => t.IsDeleted == false);
            entity.Property(e => e.FullName).HasMaxLength(255);
        }
    }
}
