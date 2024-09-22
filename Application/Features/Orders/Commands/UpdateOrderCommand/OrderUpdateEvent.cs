using Application.Common.Interfaces;
using Application.DTOs;
using Domain.Common;
using Domain.Entities.Checkout;
using MediatR;

namespace Application.Features.Orders.Commands.UpdateOrderCommand
{
    class OrderUpdateEvent : DomainEvent
    {
        public Order Order { get; set; }
        public OrderUpdateEvent(Order order)
        {
            Order = order;
        }

        public class OrderUpdateEventHandler : INotificationHandler<OrderUpdateEvent>
        {
            private readonly IEmailService _emailService;

            public OrderUpdateEventHandler(IEmailService emailService)
            {
                _emailService = emailService;
            }

            public async Task Handle(OrderUpdateEvent notification, CancellationToken cancellationToken)
            {
                EmailDTO emailRequest = new EmailDTO
                {
                    To = "maty.giraudo@hotmail.com",
                    Subject = "Orden modificada",
                    Body = $"Se ha modificado una orden: {notification.Order} - {notification.Order.Id}",
                    From = "1994elmaty@gmail.com"
                };

                //await _emailService.SendAsync(emailRequest);
            }
        }


    }

}
