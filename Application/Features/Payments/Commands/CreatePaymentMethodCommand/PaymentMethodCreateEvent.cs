using Application.Common.Interfaces;
using Application.DTOs;
using Application.Features.Orders.Commands.CreateOrderCommand;
using Domain.Common;
using Domain.Entities.Checkout;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Payments.Commands.CreatePaymentMethodCommand
{
    public class PaymentMethodCreateEvent : DomainEvent
    {
        public PaymentMethod PaymentMethod { get; set; }

        public PaymentMethodCreateEvent(PaymentMethod paymentMethod) {
            PaymentMethod = paymentMethod;
        }
    }

    public class PaymentMethodCreateEventHandler : INotificationHandler<PaymentMethodCreateEvent>
    {
        private readonly IEmailService _emailService;

        public PaymentMethodCreateEventHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(PaymentMethodCreateEvent notification, CancellationToken cancellationToken)
        {
            EmailDTO emailRequest = new EmailDTO
            {
                To = "maty.giraudo@hotmail.com",
                Subject = "Nuevo método de pago",
                Body = $"Se ha creado un nuevo método de pago: {notification.PaymentMethod} - {notification.PaymentMethod.Id}",
                From = "1994elmaty@gmail.com"
            };

            //await _emailService.SendAsync(emailRequest);
        }
    }
}
