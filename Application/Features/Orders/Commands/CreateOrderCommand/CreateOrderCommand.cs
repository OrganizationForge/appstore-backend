using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Application.Features.Brands.Commands.CreateBrandCommand;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Checkout;
using Domain.Entities.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.CreateOrderCommand
{

    public class CreateOrderCommand : IRequest<Response<Guid>>
    {
        public Guid UserId { get; set; }
        public ShippingDTO? Shipping { get; set; }
        public List<OrderItemDTO>? OrderItems { get; set; }

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

            foreach (var orderItem in command.OrderItems!)
            {
                var product = await _unitOfWork.Repository<Product>().GetByIdAsync(orderItem.ProductId);

                if (orderItem.Price is null || orderItem.Price == 0) orderItem.Price = product.Price;


            }

            var newOrder= _mapper.Map<Order>(command);

            

            await _unitOfWork.Repository<Order>().AddAsync(newOrder);

            newOrder.AddDomainEvent(new OrderCreateEvent(newOrder));

            await _unitOfWork.Save(cancellationToken);

            return new Response<Guid>(newOrder.Id);
        }
    }
}
