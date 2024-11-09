﻿using Domain.Entities.Checkout;
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

            builder.OwnsOne(p => p.ShippingAddress, address =>
            {
                address.Property(a => a.Street)
                       .IsRequired()
                       .HasMaxLength(100)
                       .HasColumnName("Street");

                address.Property(a => a.HouseNumber)
                       .IsRequired()
                       .HasColumnName("HouseNumber");

                address.Property(a => a.AdditionalInfo)
                       .IsRequired()
                       .HasMaxLength(250)
                       .HasColumnName("AdditionalInfo");

                address.Property(a => a.City)
                       .IsRequired()
                       .HasMaxLength(50)
                       .HasColumnName("City");

                address.Property(a => a.State)
                       .IsRequired()
                       .HasMaxLength(50)
                       .HasColumnName("State");

                address.Property(a => a.Country)
                       .IsRequired()
                       .HasMaxLength(50)
                       .HasColumnName("Country");

                address.Property(a => a.ZipCode)
                       .IsRequired()
                       .HasMaxLength(10)
                       .HasColumnName("ZipCode");
            });

        }
    }
}
