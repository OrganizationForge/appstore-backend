using Domain.Entities.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class LanguageConfig : IEntityTypeConfiguration<Idiom>
    {
        public void Configure(EntityTypeBuilder<Idiom> builder)
        {
            builder.ToTable("Languages");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Code)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(l => l.Description)
                .HasMaxLength(254);

            builder.Property(l => l.CreatedBy)
                .HasMaxLength(50);

            builder.Property(l => l.ModifiedBy)
                .HasMaxLength(50);
        }
    }
}
