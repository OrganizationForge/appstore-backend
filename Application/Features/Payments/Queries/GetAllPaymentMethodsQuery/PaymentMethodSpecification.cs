using Ardalis.Specification;
using Domain.Entities;
using Domain.Entities.Checkout;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Payments.Queries.GetAllPaymentMethodsQuery
{
    public class PaymentMethodSpecification : Specification<PaymentMethod>
    {
        public PaymentMethodSpecification()
        {
            Query.Where(x => x.DeletedDate == null);
        }
    }
}
