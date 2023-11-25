using Lokata.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lokata.DataAccess.TypeConfigurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> entity)
        {
            entity.ToTable("Document");

            entity.Property(e => e.Filename)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsFixedLength();
        }
    }
}
