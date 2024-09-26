using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class AvailabilityConfig : IEntityTypeConfiguration<Availability>
    {
        public void Configure(EntityTypeBuilder<Availability> builder)
        {
            builder.ToTable("Availabitities");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(120);

        }
    }
}
