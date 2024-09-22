using Domain.Entities.Checkout;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class ShippingConfig : IEntityTypeConfiguration<Shipping>
    {
        public void Configure(EntityTypeBuilder<Shipping> builder)
        {
            builder.ToTable("Shippings");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.ShippingAddress)
               .HasMaxLength(254);

            builder.Property(p => p.DateShipped);

            builder.HasOne(p => p.ShippingMethod)
                .WithMany(sm => sm.Shippings)
                .HasForeignKey(p => p.ShippingMethodId);
        }
    }
}
