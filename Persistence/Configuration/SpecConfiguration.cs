using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    internal class SpecConfiguration : IEntityTypeConfiguration<Spec>
    {
        public void Configure(EntityTypeBuilder<Spec> builder)
        {
            builder.ToTable("Specs");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name)
                    .IsRequired();

            builder.Property(p => p.Type)
                    .IsRequired();

            builder.HasOne(c => c.ParentSpec)
                    .WithMany(c => c.Childrens) 
                    .HasForeignKey(c => c.ParentId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
