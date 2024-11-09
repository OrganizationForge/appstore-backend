using Domain.Common;
using Domain.Entities.ValueObjects;

namespace Domain.Entities.Checkout
{
    public class Shipping : AuditableBaseEntity
    {
        public Address? ShippingAddress { get; set; }
        public DateTime? DateShipped { get; set; }
        public Guid ShippingMethodId { get; set; }

        public virtual ShippingMethod? ShippingMethod { get; set; }
        public virtual Order? Order { get; set; }

    }
}
