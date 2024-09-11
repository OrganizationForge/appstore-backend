using Domain.Common;

namespace Domain.Entities.Checkout
{
    public class PaymentMethod : AuditableBaseEntity
    {
        public string? Description { get; set; }

        public virtual ICollection<Payment>? Payments { get; set; }

    }
}
