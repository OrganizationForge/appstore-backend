using Domain.Common;

namespace Domain.Entities.Checkout
{
    public class Order : AuditableBaseEntity
    {
        public Guid UserId { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Guid PaymentId { get; set; }

        //public Shipping? Shipping { get; set; }
        public virtual Payment? Payment { get; set; }
    }

}
