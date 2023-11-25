using Lokata.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lokata.DataAccess.TypeConfigurations
{
    public class TargetsOrCardTakeConfiguration : IEntityTypeConfiguration<TargetsOrCardTake>
    {
        public void Configure(EntityTypeBuilder<TargetsOrCardTake> entity)
        {
            entity.ToTable("TargetsOrCardTake");
            entity.HasQueryFilter(t => t.IsDeleted == false);
            entity.HasOne(d => d.Approach).WithMany(p => p.TargetsOrCardTakes)
                .HasForeignKey(d => d.ApproachId)
                .HasConstraintName("FK_TargetsOrCardTake_Approach");

            entity.HasOne(d => d.Competitor).WithMany(p => p.TargetsOrCardTakes)
                .HasForeignKey(d => d.CompetitorId)
                .HasConstraintName("FK_TargetsOrCardTake_Competitor");
        }
    }
}
