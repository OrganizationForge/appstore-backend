using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Checkout
{
    public enum OrderStatus
    {
        New,
        Pending, 
        Completed, 
        Cancelled
    }
}
