using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class ProductFileConfig : IEntityTypeConfiguration<ProductFile>
    {
        public void Configure(EntityTypeBuilder<ProductFile> builder)
        {
            builder.ToTable("ProductFiles");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.NameImage)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.UrlImage)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.ProductId)
                .IsRequired();

            builder.Property(p => p.CreatedBy)
               .HasMaxLength(50);

            builder.Property(p => p.ModifiedBy)
                .HasMaxLength(50);
        }
    }
}
