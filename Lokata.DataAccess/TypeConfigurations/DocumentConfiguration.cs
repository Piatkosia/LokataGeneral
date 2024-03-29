﻿using Lokata.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lokata.DataAccess.TypeConfigurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> entity)
        {
            entity.ToTable("Document");
            entity.HasQueryFilter(t => t.IsDeleted == false);
            entity.Property(e => e.Filename)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.HasMany(e => e.Instructors).WithMany(e => e.Documents);
        }
    }
}
