using Application.Common.Interfaces;
using Application.Common.Wrappers;
using AutoMapper;
using Domain.Entities.Checkout;
using MediatR;

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


            if (command.Shipping != null)
            {
                if (order.Shipping != null)
                {
                    // Mapear los cambios del Shipping si existe
                    _mapper.Map(command.Shipping, order.Shipping);
                }
            }

            // 2. Manejar OrderItems (actualizar, agregar o eliminar)
            if (command.OrderItems != null && command.OrderItems.Any())
            {
                // Obtener los IDs de los OrderItems que se reciben
                var receivedItemIds = command.OrderItems.Select(oi => oi.Id).ToList();

                // Eliminar los OrderItems que no están
                var itemsToRemove = order.OrderItems
                    .Where(oi => !receivedItemIds.Contains(oi.Id))
                    .ToList();

                foreach (var itemToRemove in itemsToRemove)
                {
                    order.OrderItems.Remove(itemToRemove);
                    await _unitOfWork.Repository<OrderItem>().DeleteAsync(itemToRemove);
                }

                // Actualizar o agregar los OrderItems que se reciben
                foreach (var receivedItem in command.OrderItems)
                {
                    var existingItem = order.OrderItems.FirstOrDefault(oi => oi.Id == receivedItem.Id);

                    if (existingItem != null)
                    {
                        // Si el OrderItem existe, actualizarlo
                        _mapper.Map(receivedItem, existingItem);
                    }
                    else
                    {
                        var newItem = _mapper.Map<OrderItem>(receivedItem);
                        order.OrderItems.Add(newItem);
                    }
                }
            }

   
            await _unitOfWork.Save(cancellationToken);

            return new Response<string>("Successfully updated");
        }
    }
}
