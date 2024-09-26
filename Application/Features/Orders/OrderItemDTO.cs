using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders
{
    public class OrderItemDTO
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; } 
        public Guid ProductId { get; set; }

    }
}
