using Application.Common.Interfaces;
using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.CreateBrandCommand
{
    public class BrandCreateEvent : DomainEvent
    {
        public Brand Brand { get; set; }
        public BrandCreateEvent(Brand brand)
        {
            Brand = brand;
        }
    }
    public class BrandCreateEventHandler : INotificationHandler<BrandCreateEvent>
    {
        private readonly IEmailService _emailService;

        public BrandCreateEventHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(BrandCreateEvent notification, CancellationToken cancellationToken)
        {
            EmailDTO emailRequest = new EmailDTO 
            {
                To = "maty.giraudo@hotmail.com",
                Subject = "Nuevo marca guardada",
                Body = $"Has ingresado una nueva marca : {notification.Brand} - {notification.Brand.Description}",
                From = "1994elmaty@gmail.com"
            };

            //await _emailService.SendAsync(emailRequest);
        }
    }
}
