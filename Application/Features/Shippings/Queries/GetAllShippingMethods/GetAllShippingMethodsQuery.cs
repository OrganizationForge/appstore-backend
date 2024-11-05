using Application.Common.Interfaces;
using Application.Common.Wrappers;
using AutoMapper;
using Domain.Entities.Checkout;
using MediatR;

namespace Application.Features.Shippings.Queries.GetAllShippingMethods
{
    public class GetAllShippingMethodsQuery : IRequest<Response<List<ShippingMethodDTO>>> { }

    public class GetAllShippingMethodsQueryHandler : IRequestHandler<GetAllShippingMethodsQuery, Response<List<ShippingMethodDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //private readonly IDistributedCache _distributedCache;

        public GetAllShippingMethodsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<ShippingMethodDTO>>> Handle(GetAllShippingMethodsQuery request, CancellationToken cancellationToken)
        {
            var listShippinhMethods = await _unitOfWork.Repository<ShippingMethod>().ListAsync(cancellationToken);

            var result = _mapper.Map<List<ShippingMethodDTO>>(listShippinhMethods);

            return new Response<List<ShippingMethodDTO>>(result);
        }
    }
}
