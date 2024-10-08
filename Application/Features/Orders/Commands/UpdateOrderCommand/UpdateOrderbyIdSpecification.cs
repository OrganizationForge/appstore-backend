using Ardalis.Specification;
using Domain.Entities.Checkout;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.UpdateOrderCommand
{
    public class UpdateOrderbyIdSpecification : Specification<Order>, ISingleResultSpecification<Order>
    {
        public UpdateOrderbyIdSpecification(Guid id)
        {

            Query.Where(p => p.Id == id)
                .Include(p => p.Payment)
                .Include(p => p.Shipping)
                .Include(p => p.OrderItems);
        }
    }
}

