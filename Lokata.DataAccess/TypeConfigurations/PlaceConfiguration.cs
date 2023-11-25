using Lokata.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lokata.DataAccess.TypeConfigurations
{
    public class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> entity)
        {
            entity.ToTable("Place");
            entity.HasQueryFilter(t => t.IsDeleted == false);
            entity.HasOne(d => d.AddressNavigation).WithMany(p => p.Places)
                .HasForeignKey(d => d.Address)
                .HasConstraintName("FK_Place_Address");
        }
    }
}
