using Lokata.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lokata.DataAccess.TypeConfigurations
{
    internal class InstructorDocumentConfiguration : IEntityTypeConfiguration<InstructorDocument>
    {
        public void Configure(EntityTypeBuilder<InstructorDocument> entity)
        {
            entity.ToTable("InstructorDocument");
            entity.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}
