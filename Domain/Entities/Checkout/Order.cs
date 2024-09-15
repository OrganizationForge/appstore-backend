using Domain.Common;

namespace Domain.Entities.Checkout
{
    public class Order : AuditableBaseEntity
    {
        public Guid UserId { get; set; }
        public OrderStatus Status { get; set; }
        public Guid? PaymentId { get; set; }
        public Guid? ShippingId { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual Shipping? Shipping { get; set; }
        public virtual Payment? Payment { get; set; }
    }

}
