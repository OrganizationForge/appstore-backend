using Ardalis.Specification;
using Domain.Entities.Checkout;

namespace Application.Features.Orders.Queries.GetAllOrders
{
    public class OrderSpecification : Specification<Order>
    {
        public OrderSpecification(PaginationOrdersParameters parameters)
        {
            Query.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize);

            if (parameters.Status != null)
                Query.Where(x => x.Status == (OrderStatus)parameters.Status);

            Query
                .Include(x => x.OrderItems);
        }
    }
}
