using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Payments.Commands.CreatePaymentCommand
{
    public class CreatePaymentResponse
    {
        public string? CheckoutUrl { get; set; }
        public string? PaymentId { get; set; }
        public string? PreferenceId { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? ExternalReference { get; set; }
    }
}
