using Application.Common.Interfaces;
using Application.DTOs;
using Application.Features.Language.Commands.CreateLanguageCommand;
using Domain.Common;
using Domain.Entities;
using Domain.Entities.Library;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.CreateBrandCommand
{
    public class BrandCreateEvent : BaseEvent
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

            await _emailService.SendAsync(emailRequest);
        }
    }
}
