﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class QuantityTypeConfig : IEntityTypeConfiguration<QuantityType>
        {
            public void Configure(EntityTypeBuilder<QuantityType> builder)
            {
                builder.ToTable("QuantityTypes");

                builder.HasKey(p => p.Id);

                builder.Property(p => p.Description)
                    .HasMaxLength(254);
            }
        }
}
