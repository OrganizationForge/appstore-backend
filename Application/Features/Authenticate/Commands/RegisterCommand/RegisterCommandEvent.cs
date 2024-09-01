using Application.Common.Interfaces;
using Application.Common.Mailing;
using Application.DTOs;
using Application.Features.Language.Commands.CreateLanguageCommand;
using Domain.Common;
using Domain.Entities.Library;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authenticate.Commands.RegisterCommand
{
    public class RegisterCommandEvent : BaseEvent
    {
        public MailRequest Request { get; set; }
        public RegisterCommandEvent(MailRequest request)
        {
            Request = request;
        }
    }

    public class RegisterCommandEventHandler : INotificationHandler<RegisterCommandEvent>
    {
        private readonly IEmailService _emailService;

        public RegisterCommandEventHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(RegisterCommandEvent notification, CancellationToken cancellationToken)
        {
            await _emailService.SendAsync(notification.Request, cancellationToken);
        }
    }
}
