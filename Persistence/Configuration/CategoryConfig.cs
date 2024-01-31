using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(c => c.ParentCategory)
                .WithMany(c => c.Childrens) // Nombre de la propiedad de navegación en la clase Category
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Restrict); // Opcional: especifica el comportamiento de eliminación
        }
    }
}
