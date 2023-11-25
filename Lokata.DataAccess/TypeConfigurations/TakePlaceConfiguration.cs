using Lokata.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lokata.DataAccess.TypeConfigurations
{
    public class TakePlaceConfiguration : IEntityTypeConfiguration<TakePlace>
    {
        public void Configure(EntityTypeBuilder<TakePlace> entity)
        {
            entity.ToTable("TakePlace");

            entity.HasOne(d => d.Approach).WithMany(p => p.TakePlaces)
                .HasForeignKey(d => d.ApproachId)
                .HasConstraintName("FK_TakePlace_Approach");

            entity.HasOne(d => d.Competitor).WithMany(p => p.TakePlaces)
                .HasForeignKey(d => d.CompetitorId)
                .HasConstraintName("FK_TakePlace_Competitor");
        }
    }
}
