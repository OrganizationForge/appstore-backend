using Domain.Common;
using Domain.Entities.Products;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Category : AuditableBaseEntity
    {
        public string? Description { get; set; }
        public string? UrlImage { get; set; }

        // Propiedad de navegación hacia la categoría padre
        public int? ParentId { get; set; }
        public Category? ParentCategory { get; set; }

        // Colección de categorías hijas
        public virtual List<Category>? Childrens { get; set; }
        public virtual List<Spec>? Specs { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
