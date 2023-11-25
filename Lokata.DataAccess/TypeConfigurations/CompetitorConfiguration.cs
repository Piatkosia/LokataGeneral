using Lokata.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lokata.DataAccess.TypeConfigurations
{
    public class CompetitorConfiguration : IEntityTypeConfiguration<Competitor>
    {
        public void Configure(EntityTypeBuilder<Competitor> entity)
        {
            entity.ToTable("Competitor");
            entity.HasQueryFilter(t => t.IsDeleted == false);
            entity.Property(e => e.FullName).HasMaxLength(255);

            entity.HasOne(d => d.Sex).WithMany(p => p.CompetitorList)
                .HasForeignKey(d => d.SexId)
                .HasConstraintName("FK_Competitor_Sex");
        }
    }
}
