using Application.Common.Parameters;

namespace Application.Features.Orders.Queries.GetAllOrders
{
    public class PaginationOrdersParameters : RequestParameters
    {
        public int? Status { get; set; }

    }
}
