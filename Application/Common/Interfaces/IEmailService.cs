using Application.DTOs;

namespace Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequestDto request);
    }
}
