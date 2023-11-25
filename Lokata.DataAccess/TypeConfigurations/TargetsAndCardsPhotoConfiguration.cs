using Lokata.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lokata.DataAccess.TypeConfigurations
{
    public class TargetsAndCardsPhotoConfiguration : IEntityTypeConfiguration<TargetsAndCardsPhoto>
    {
        public void Configure(EntityTypeBuilder<TargetsAndCardsPhoto> entity)
        {
            entity.ToTable("TargetsAndCardsPhoto");
            entity.HasQueryFilter(t => t.IsDeleted == false);
            entity.HasOne(d => d.Approach).WithMany(p => p.TargetsAndCardsPhotos)
                .HasForeignKey(d => d.ApproachId)
                .HasConstraintName("FK_TargetsAndCardsPhoto_Approach");

            entity.HasOne(d => d.Competitor).WithMany(p => p.TargetsAndCardsPhotos)
                .HasForeignKey(d => d.CompetitorId)
                .HasConstraintName("FK_TargetsAndCardsPhoto_Competitor");
        }
    }
}
