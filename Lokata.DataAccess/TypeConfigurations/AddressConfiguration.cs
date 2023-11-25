using Lokata.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lokata.DataAccess.TypeConfigurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.Property(e => e.FullName).HasMaxLength(254);
            builder.Property(e => e.Number).HasMaxLength(50);
            builder.Property(e => e.PostalCode).HasMaxLength(50);
            builder.Property(e => e.PostalPlace).HasMaxLength(254);
            builder.Property(e => e.Street).HasMaxLength(254);
            builder.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}
