using Lokata.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lokata.DataAccess.TypeConfigurations
{
    public class ScoreCardConfiguration : IEntityTypeConfiguration<ScoreCard>
    {
        public void Configure(EntityTypeBuilder<ScoreCard> entity)
        {
            entity.ToTable("ScoreCard");

            entity.HasOne(d => d.Approach).WithMany(p => p.ScoreCards)
                .HasForeignKey(d => d.ApproachId)
                .HasConstraintName("FK_ScoreCard_Approach");

            entity.HasOne(d => d.Competitor).WithMany(p => p.ScoreCards)
                .HasForeignKey(d => d.CompetitorId)
                .HasConstraintName("FK_ScoreCard_Competitor");
        }
    }
}
