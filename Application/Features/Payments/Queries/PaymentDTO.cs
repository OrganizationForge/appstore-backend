using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Payments.Queries.GetAllPaymentMethodsQuery;

namespace Application.Features.Payments.Queries
{
    public class PaymentDTO
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string? Status { get; set; }
        public virtual PaymentMethodDTO? PaymentMethod { get; set; }

    }
}
