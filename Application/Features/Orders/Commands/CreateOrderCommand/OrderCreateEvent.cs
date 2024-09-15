using Application.Common.Interfaces;
using Application.DTOs;
using Domain.Common;
using Domain.Entities.Checkout;
using MediatR;

namespace Application.Features.Orders.Commands.CreateOrderCommand
{
    public class OrderCreateEvent : DomainEvent
    {
        public Order Order { get; set; }
        public OrderCreateEvent(Order order)
        {
            Order = order;
        }
    }
    public class OrderCreateEventHandler : INotificationHandler<OrderCreateEvent>
    {
        private readonly IEmailService _emailService;

        public OrderCreateEventHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(OrderCreateEvent notification, CancellationToken cancellationToken)
        {
            EmailDTO emailRequest = new EmailDTO
            {
                To = "maty.giraudo@hotmail.com",
                Subject = "Nueva Orden Creada",
                Body = $"Se ha creado una nueva orden: {notification.Order} - {notification.Order.Id}",
                From = "1994elmaty@gmail.com"
            };

            //await _emailService.SendAsync(emailRequest);
        }
    }
}
