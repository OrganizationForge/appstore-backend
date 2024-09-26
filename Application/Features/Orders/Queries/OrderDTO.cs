using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries
{
    public class OrderDTO
    {
        public Guid UserId { get; set; }
        public int Status { get; set; }
        public Guid? PaymentId { get; set; }
        public Guid? ShippingId { get; set; }
        public List<OrderItemDTO>? OrderItems { get; set; }
    }
}
