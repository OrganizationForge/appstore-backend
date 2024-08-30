using Application.Common.Mailing;
using Application.DTOs;

namespace Application.Common.Interfaces
{
    public interface IEmailService
    {
        //Task SendAsync(EmailDTO request);
        Task SendAsync(MailRequest request, CancellationToken cancellationToken);
    }
}
