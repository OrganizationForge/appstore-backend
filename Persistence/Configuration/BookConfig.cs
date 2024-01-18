using Domain.Entities.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Publication)
                .IsRequired();

            builder.Property(b => b.Description)
                .HasMaxLength(500);

            builder.Property(b => b.Pages) 
                .IsRequired();

            builder.Property(p => p.CreatedBy)
                .HasMaxLength(50);

            builder.Property(p => p.ModifiedBy)
                .HasMaxLength(50);

            builder.HasOne(b => b.Language)
                .WithMany(l => l.Books)
                .HasForeignKey(b => b.LanguageId);
        }
    }
}
