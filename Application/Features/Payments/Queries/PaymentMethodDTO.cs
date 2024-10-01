using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Payments.Queries
{
    public class PaymentMethodDTO
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
    }
}
