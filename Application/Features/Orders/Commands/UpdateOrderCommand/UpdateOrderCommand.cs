using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Application.Features.Orders.Queries.GetOrderById;
using Application.Features.Shipping.Queries;
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
        private readonly ICurrentUserService _currentUserService;

        public UpdateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<string>> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            DateTime fechaActual = DateTime.Now;

            //var order = await _unitOfWork.Repository<Order>().GetByIdAsync(command.OrderId);
            var order = await _unitOfWork.Repository<Order>().FirstOrDefaultAsync(new OrderByIdSpecification(command.OrderId), cancellationToken);

            if (order is null)
            {

                return new Response<string>("Orden no encontrada");
            }

            order.ModifiedBy = _currentUserService.User.Id;
            order.ModifiedDate = fechaActual;

            if (command.Shipping != null)
            {
                if (order.Shipping != null)
                {
                    order.Shipping.ModifiedBy = _currentUserService.User.Id;
                    order.Shipping.ModifiedDate = fechaActual;
                    // Mapear los cambios del Shipping si existe
                    _mapper.Map(command.Shipping, order.Shipping);
                }
            }

            if (command.OrderItems != null && command.OrderItems.Any())
            {

                var receivedItemIds = command.OrderItems.Select(oi => oi.Id).ToList();

                // Eliminar los OrderItems que no están
                var itemsToRemove = order.OrderItems
                    .Where(oi => !receivedItemIds.Contains(oi.Id) && oi.DeletedDate is null)
                    .ToList();

                foreach (var itemToRemove in itemsToRemove)
                {
                    itemToRemove.DeletedDate = fechaActual;
                    itemToRemove.DeletedBy = _currentUserService.User.Id;
                }

                // Actualizar o agregar los OrderItems que se reciben
                foreach (var receivedItem in command.OrderItems)
                {
                    // Si el item tiene un Id autogenerado, detecta si es nuevo por su GUID por defecto
                    if (receivedItem.Id == Guid.Empty)
                    {
                        // Este es un nuevo item, se debe agregar
                        var newItem = _mapper.Map<OrderItem>(receivedItem);
                        newItem.CreatedBy = _currentUserService.User.Id;
                        order.OrderItems.Add(newItem);
                    }
                    else
                    {
                        // Este es un item existente, buscar y actualizar
                        var existingItem = order.OrderItems.FirstOrDefault(oi => oi.Id == receivedItem.Id && oi.DeletedDate is null);
                        if (existingItem != null)
                        {
                            existingItem.ModifiedBy = _currentUserService.User.Id;
                            existingItem.ModifiedDate = DateTime.UtcNow;
                            _mapper.Map(receivedItem, existingItem);
                        }
                    }
                }
            }


            
            await _unitOfWork.Repository<Order>().UpdateAsync(order);
            await _unitOfWork.Repository<Order>().SaveChangesAsync(cancellationToken);



            return new Response<string>("Successfully updated");
        }
    }
}
