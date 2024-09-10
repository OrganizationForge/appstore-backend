using Domain.Common;

namespace Domain.Entities.Checkout
{
    public class Payment : AuditableBaseEntity
    {
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; } 
     


        public virtual Order? Order { get; set; }
    }
}
