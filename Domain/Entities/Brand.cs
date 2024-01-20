using Domain.Common;
using Domain.Entities.Products;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Brand : AuditableBaseEntity
    {
        public string? BrandName { get; set; }
        public string? Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product>? Products { get; set; }
    }
}
