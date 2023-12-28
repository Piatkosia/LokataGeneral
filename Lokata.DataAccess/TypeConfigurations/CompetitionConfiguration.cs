using Lokata.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lokata.DataAccess.TypeConfigurations
{
    public class CompetitionConfiguration : IEntityTypeConfiguration<Competition>
    {
        public void Configure(EntityTypeBuilder<Competition> entity)
        {
            entity.ToTable("Competition");
            entity.HasQueryFilter(t => t.IsDeleted == false);
            entity.Property(e => e.Name).HasMaxLength(255);
        }
    }
}
