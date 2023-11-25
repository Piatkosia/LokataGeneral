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

            entity.Property(e => e.FullName).HasMaxLength(255);

            entity.HasOne(d => d.Sex).WithMany(p => p.CompetitorList)
                .HasForeignKey(d => d.Sex)
                .HasConstraintName("FK_Competitor_Sex");
        }
    }
}
