using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Customers;

namespace Persistence.Configuration
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.Email)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.OwnsOne(p => p.Address, address =>
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
