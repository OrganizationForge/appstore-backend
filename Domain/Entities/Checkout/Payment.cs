using Domain.Common;

namespace Domain.Entities.Checkout
{
    public class Payment : AuditableBaseEntity
    {
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; } 
        public Guid OrderId { get; set; }
        public Guid PaymentMethodId { get; set; }

        public virtual PaymentMethod? PaymentMethod { get; set; }
        public virtual Order? Order { get; set; }
    }
}
