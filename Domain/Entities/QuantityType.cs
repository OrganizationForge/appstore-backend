using Domain.Common;
using Domain.Entities.Products;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class QuantityType : AuditableBaseEntity
    {
        public string? Description { get; set; } 

        [JsonIgnore]
        public virtual ICollection<Product>? Products { get; set; }
    }
}
