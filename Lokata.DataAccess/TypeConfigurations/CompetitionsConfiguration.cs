using Lokata.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lokata.DataAccess.TypeConfigurations
{
    public class CompetitionsConfiguration : IEntityTypeConfiguration<Competitions>
    {
        public void Configure(EntityTypeBuilder<Competitions> entity)
        {
            entity.ToTable("Competitions");
            entity.HasQueryFilter(t => t.IsDeleted == false);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Place).WithMany(p => p.CompetitionsList)
                .HasForeignKey(d => d.PlaceId)
                .HasConstraintName("FK_Competitions_Place");
        }
    }
}
