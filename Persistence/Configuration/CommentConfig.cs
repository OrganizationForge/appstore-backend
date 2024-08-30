using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.CustomerName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Content)
                .IsRequired()
                .HasMaxLength(1023);

            builder.Property(c => c.Pros)
                .HasMaxLength(253);

            builder.Property(c => c.Cons)
                .HasMaxLength(253);

            builder.Property(c => c.Rating)
                .IsRequired()
                .HasMaxLength(253);

            builder.Property(c => c.CreatedBy)
                .HasMaxLength(50);

            builder.Property(c => c.ModifiedBy)
                .HasMaxLength(50);

            builder.HasOne(c => c.Product)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ProductId);
        }
    }
}
