using Lokata.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lokata.DataAccess.TypeConfigurations
{
    public class ApproachConfiguration : IEntityTypeConfiguration<Approach>
    {
        public void Configure(EntityTypeBuilder<Approach> entity)
        {
            entity.ToTable("Approach");

            entity.HasOne(d => d.Competition).WithMany(p => p.Approaches)
                .HasForeignKey(d => d.CompetitionId)
                .HasConstraintName("FK_Approach_Competition");

            entity.HasOne(d => d.Competitions).WithMany(p => p.Approaches)
                .HasForeignKey(d => d.CompetitionsId)
                .HasConstraintName("FK_Approach_Competitions");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Approaches)
                .HasForeignKey(d => d.InstructorId)
                .HasConstraintName("FK_Approach_Instructor");

            entity.HasOne(d => d.Umpire).WithMany(p => p.Approaches)
                .HasForeignKey(d => d.UmpireId)
                .HasConstraintName("FK_Approach_Umpire");
        }
    }
}
