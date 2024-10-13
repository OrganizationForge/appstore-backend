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

            var shipping = await _unitOfWork.Repository<Shipping>().AddAsync(new Shipping
            {
                ShippingAddress = command.Shipping.ShippingAddress,
                ShippingMethodId = command.Shipping.shippingMethodId
            });

            Order newOrder = new Order();
            newOrder.Status = OrderStatus.New; 
            newOrder.ShippingId = shipping.Id;


            var order = await _unitOfWork.Repository<Order>().AddAsync(newOrder);

            if (order != null)
            {
                foreach (var orderItem in command.OrderItems!)
                {
                    var product = await _unitOfWork.Repository<Product>().GetByIdAsync(orderItem.ProductId);
                    if (product != null)
                    {
                        await _unitOfWork.Repository<OrderItem>().AddAsync(new OrderItem
                        {
                            Quantity = orderItem.Quantity,
                            Price = (decimal)orderItem.Price,
                            OrderId = order.Id,
                            ProductId = product.Id
                        });
                    }
                }


            }
            //var newOrder = _mapper.Map<Order>(command);
            newOrder.AddDomainEvent(new OrderCreateEvent(newOrder));

            await _unitOfWork.Save(cancellationToken);

            return new Response<Guid>(newOrder.Id);
        }
    }
}
