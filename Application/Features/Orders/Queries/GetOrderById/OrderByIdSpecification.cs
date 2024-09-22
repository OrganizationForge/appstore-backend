using Ardalis.Specification;
using Domain.Entities.Checkout;
using Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.GetOrderById
{
    public class OrderByIdSpecification : Specification<Order>, ISingleResultSpecification<Order>
    {
        public OrderByIdSpecification(Guid id)
        {

            Query.Where(p => p.Id == id)
                .Include(p => p.UserId);
        }
    }
}
