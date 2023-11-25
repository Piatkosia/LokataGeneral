using Microsoft.EntityFrameworkCore;
using Lokata.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lokata.DataAccess.TypeConfigurations
{
    public class SexConfiguration : IEntityTypeConfiguration<Sex>
    {
        public void Configure(EntityTypeBuilder<Sex> entity)
        {
            entity.ToTable("Sex");
            entity.HasQueryFilter(t => t.IsDeleted == false);
            entity.Property(e => e.Name).HasMaxLength(50);
        }
    }
}
