using Application.Common.Interfaces;
using Application.Common.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Shipping.Commands.CreateShippingMethod
{
    public class CreateShippingMethodCommand : IRequest<Response<Guid>>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? DeliveryTime { get; set; }
        public decimal Price { get; set; } = 0;
    }

    public class CreateShippingMethodCommandHandler : IRequestHandler<CreateShippingMethodCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateShippingMethodCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreateShippingMethodCommand command, CancellationToken cancellationToken)
        {
            var newShippingMethod = _mapper.Map<ShippingMethod>(command);

            await _unitOfWork.Repository<ShippingMethod>().AddAsync(newShippingMethod);

            //newShippingMethod.AddDomainEvent(new BrandCreateEvent(newShippingMethod));

            await _unitOfWork.Save(cancellationToken);

            return new Response<Guid>(newShippingMethod.Id);
        }
    }
}
