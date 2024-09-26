using Application.Features.Payments;
using Application.Features.Payments.Commands.CreatePaymentCommand;

namespace Application.Common.Interfaces
{
    public interface IPaymentService
    {
        Task<CreatePaymentResponse> CreatePaymentAsync(CreatePaymentCommand command);
    }
}
