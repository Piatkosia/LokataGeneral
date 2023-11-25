using Lokata.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lokata.DataAccess.TypeConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.ToTable("Category");
            entity.HasQueryFilter(t => t.IsDeleted == false);
            entity.Property(e => e.CategoryName).HasMaxLength(255);
        }
    }
}
