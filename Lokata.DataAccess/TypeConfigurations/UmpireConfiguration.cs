using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lokata.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lokata.DataAccess.TypeConfigurations
{
    public class UmpireConfiguration : IEntityTypeConfiguration<Umpire>
    {
        public void Configure(EntityTypeBuilder<Umpire> entity)
        {
            entity.ToTable("Umpire");

            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.PermissionDocumentNumber).HasMaxLength(255);
        }
    }
}
