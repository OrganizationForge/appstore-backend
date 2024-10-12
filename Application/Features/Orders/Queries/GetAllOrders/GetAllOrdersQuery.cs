using Application.Common.Interfaces;
using Application.Common.Wrappers;
using AutoMapper;
using Domain.Entities.Checkout;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : PaginationOrdersParameters, IRequest<PagedResponse<List<OrderDTO>>> { }

    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, PagedResponse<List<OrderDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly IDistributedCache _distributedCache;

        public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PagedResponse<List<OrderDTO>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var listAllProducts = await _unitOfWork.Repository<Order>().ListAsync(new OrderSpecification(request), cancellationToken);
            var totalRecords = await _unitOfWork.Repository<Order>().CountAsync(new OrderSpecification(request), cancellationToken);
            var result = _mapper.Map<List<OrderDTO>>(listAllProducts);

            return new PagedResponse<List<OrderDTO>>(result, request.PageNumber, request.PageSize, totalRecords);
        }
    }
}
