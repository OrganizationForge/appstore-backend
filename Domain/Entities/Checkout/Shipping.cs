using Domain.Common;

namespace Domain.Entities.Checkout
{
    public class Shipping : AuditableBaseEntity
    {
        public string? ShippingAddress { get; set; }
        public DateTime? DateShipped { get; set; }
        public Guid ShippingMethodId { get; set; }

        public virtual ShippingMethod? ShippingMethod { get; set; }
        public virtual Order? Order { get; set; }

    }
}
