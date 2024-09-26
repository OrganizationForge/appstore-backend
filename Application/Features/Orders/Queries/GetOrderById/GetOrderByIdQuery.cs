using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Application.Features.Products.Queries.GetProductById;
using AutoMapper;
using Domain.Entities.Checkout;
using Domain.Entities.Products;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<Response<OrderDTO>>
    {
        public Guid Id { get; set; }
    }

    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Response<OrderDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetOrderByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<OrderDTO>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Repository<Order>().FirstOrDefaultAsync(new OrderByIdSpecification(request.Id), cancellationToken);

            if (order == null)
                throw new KeyNotFoundException($"Registro no encontrado con id {request.Id}");
            else
            {
                var result = _mapper.Map<OrderDTO>(order);

                return new Response<OrderDTO>(result);
            }
        }
    }
}
