using Domain.Entities.Checkout;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    internal class ShippingMethodConfig : IEntityTypeConfiguration<ShippingMethod>
    {
        public void Configure(EntityTypeBuilder<ShippingMethod> builder)
        {
            builder.ToTable("ShippingMethods");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(p => p.Description)
                .HasMaxLength(254);

            builder.Property(p => p.DeliveryTime)
                .HasMaxLength(80);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}
