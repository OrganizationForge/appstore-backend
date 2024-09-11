using Domain.Entities.Checkout;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Quantity)
               .IsRequired();

            builder.Property(p => p.Price)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

            builder.HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId);

            builder.HasOne(p => p.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(p => p.OrderId);
        }
    }
}
