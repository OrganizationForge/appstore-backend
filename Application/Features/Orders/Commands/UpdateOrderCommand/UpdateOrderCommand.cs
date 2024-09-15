using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Application.Features.Orders.Commands.CreateOrderCommand;
using AutoMapper;
using Domain.Entities.Checkout;
using Domain.Entities.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.UpdateOrderCommand
{
    public class UpdateOrderCommand : IRequest<Response<string>>
    {
        public Guid OrderId { get; set; }
        public ShippingDTO? Shipping { get; set; }
        public List<OrderItemDTO>? OrderItems { get; set; }
    }

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {

            var order = await _unitOfWork.Repository<Order>().GetByIdAsync(command.OrderId);

            if (order is null)
            {
                return new Response<string>("Orden no encontrada");
            }


            
            //var newOrder = _mapper.Map<Order>(command);

            //await _unitOfWork.Repository<Order>().AddAsync(newOrder);

            //newOrder.AddDomainEvent(new OrderCreateEvent(newOrder));

            await _unitOfWork.Save(cancellationToken);

            return new Response<string>("Successfully updated");
        }
    }
}
