using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(500);

            builder.Property(p => p.PriceBase)
                .IsRequired();

            builder.Property(p => p.Warranty)
                .HasMaxLength(254);

            builder.Property(p => p.CreatedBy)
               .HasMaxLength(50);

            builder.Property(p => p.ModifiedBy)
                .HasMaxLength(50);

            builder.HasOne(p => p.Category)
            .WithMany(b => b.Products)
            .HasForeignKey(p => p.CategoryId);

            builder.HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId);

            builder.HasOne(p => p.Availability)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.AvailabilityId);

        }
    }
}
