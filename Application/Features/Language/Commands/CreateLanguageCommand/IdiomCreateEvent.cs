using Application.Common.Interfaces;
using Application.DTOs;
using Domain.Common;
using Domain.Entities.Library;
using MediatR;

namespace Application.Features.Language.Commands.CreateLanguageCommand
{
    public class IdiomCreateEvent : BaseEvent
    {
        public Idiom Idiom { get; set; }
        public IdiomCreateEvent(Idiom idiom)
        {
            Idiom = idiom;
        }
    }

    public class IdiomCreateEventHandler : INotificationHandler<IdiomCreateEvent>
    {
        private readonly IEmailService _emailService;

        public IdiomCreateEventHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(IdiomCreateEvent notification, CancellationToken cancellationToken)
        {
            EmailRequestDto emailRequest = new EmailRequestDto
            {
                To = "maty.giraudo@hotmail.com",
                Subject = "Nuevo Idioma guardado",
                Body = $"Has igresadoi un nuevo idioma : {notification.Idiom.Code} - {notification.Idiom.Description}",
                From = "1994elmaty@gmail.com"
            };

            await _emailService.SendAsync(emailRequest);
        }
    }
}
