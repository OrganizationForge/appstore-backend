using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.GetOrderPdfQuery.ViewModels
{
    public class PaymentViewModel
    {
        public string? PaymentMethod { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal Amount { get; set; }
    }

}
