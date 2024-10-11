using Application.Common.Interfaces;
using Application.DTOs;
using Application.Features.Orders.Commands.CreateOrderCommand;
using Domain.Common;
using Domain.Entities;
using Domain.Entities.Checkout;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.CreateCategoryCommand
{
    public class CategoryCreateEvent : DomainEvent
    {
        public Category Category { get; set; }
        public CategoryCreateEvent(Category category)
        {
            Category = category;
        }
    }
    public class CategoryCreateEventHandler : INotificationHandler<CategoryCreateEvent>
    {
        private readonly IEmailService _emailService;

        public CategoryCreateEventHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(CategoryCreateEvent notification, CancellationToken cancellationToken)
        {
            //EmailDTO emailRequest = new EmailDTO
            //{
            //    To = "maty.giraudo@hotmail.com",
            //    Subject = "Nueva Categoria Creada",
            //    Body = $"Se ha creado una nueva categoria: {notification.Order} - {notification.Order.Id}",
            //    From = "1994elmaty@gmail.com"
            //};

            //await _emailService.SendAsync(emailRequest);
        }
    }
}
