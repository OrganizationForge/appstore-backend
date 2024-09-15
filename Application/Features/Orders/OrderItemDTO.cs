using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders
{
    public class OrderItemDTO
    {
        public int Quantity { get; set; }
        public double? Price { get; set; } 
        public Guid ProductId { get; set; }

    }
}
