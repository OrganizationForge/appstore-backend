using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Application.Features.Categories.Queries;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Checkout;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Payments.Queries.GetAllPaymentMethodsQuery
{
    public class GetAllPaymentMethodsQuery : IRequest<Response<List<PaymentMethodDTO>>> { }

    public class GetAllPaymentMethodsQueryHandler : IRequestHandler<GetAllPaymentMethodsQuery, Response<List<PaymentMethodDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //private readonly IDistributedCache _distributedCache;

        public GetAllPaymentMethodsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<PaymentMethodDTO>>> Handle(GetAllPaymentMethodsQuery request, CancellationToken cancellationToken)
        {
            var listPaymentMethods = await _unitOfWork.Repository<PaymentMethod>().ListAsync(new PaymentMethodSpecification(), cancellationToken);

            var result = _mapper.Map<List<PaymentMethodDTO>>(listPaymentMethods);

            return new Response<List<PaymentMethodDTO>>(result);
        }
    }
}
