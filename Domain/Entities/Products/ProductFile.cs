using Domain.Common;

namespace Domain.Entities.Products
{
    public class ProductFile : AuditableBaseEntity
    {
        public string? NameImage { get; set; }
        public string? UrlImage { get; set; }
        public Guid? ProductId { get; set; }
        public virtual Product? Product { get; set; }

    }
}
