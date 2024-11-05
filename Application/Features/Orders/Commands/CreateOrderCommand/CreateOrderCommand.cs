using Application.Common.Interfaces;
using Application.Common.Wrappers;
using AutoMapper;
using Domain.Entities.Checkout;
using Domain.Entities.Products;
using MediatR;

namespace Application.Features.Orders.Commands.CreateOrderCommand
{

    public class CreateOrderCommand : IRequest<Response<Guid>>
    {
        public ShippingRequestDTO? Shipping { get; set; }
        public List<OrderItemRequestDTO>? OrderItems { get; set; }

    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {

            var newOrder = _mapper.Map<Order>(command);

            var order = await _unitOfWork.Repository<Order>().AddAsync(newOrder);

            newOrder.AddDomainEvent(new OrderCreateEvent(newOrder));

            await _unitOfWork.Save(cancellationToken);

            return new Response<Guid>(newOrder.Id);
        }
    }
}
