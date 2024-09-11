using Domain.Entities.Checkout;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Status)
               .IsRequired();

            builder.HasOne(p => p.Shipping)
                .WithOne(s => s.Order)
                .HasForeignKey<Order>(p => p.ShippingId)
                .IsRequired();

            builder.HasOne(p => p.Payment)
                .WithOne(s => s.Order)
                .HasForeignKey<Order>(p => p.PaymentId)
                .IsRequired();

            
        }       
    }
}
