using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Payments.Queries
{
    public class PaymentDTO
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string? Status { get; set; }
        public PaymentMethodDTO? PaymentMethod { get; set; }

    }
}
