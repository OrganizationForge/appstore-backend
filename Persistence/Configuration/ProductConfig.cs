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

            builder.Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(500);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.PriceBase)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.Warranty)
                .HasMaxLength(254);

            builder.Property(p => p.Rating)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.Stock)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.HasOne(p => p.Category)
            .WithMany(b => b.Products)
            .HasForeignKey(p => p.CategoryId);

            builder.HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId);

            builder.HasOne(p => p.Availability)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.AvailabilityId);

            builder.HasMany(p => p.ProductFiles)
                .WithOne(b => b.Product)
                .HasForeignKey(p => p.ProductId);



        }
    }
}
