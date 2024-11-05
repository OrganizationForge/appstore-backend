using Application.Common.Interfaces;
using Application.Common.Wrappers;
using AutoMapper;
using Domain.Entities.Checkout;
using MediatR;

namespace Application.Features.Payments.Commands.CreatePaymentMethodCommand
{
    public class CreatePaymentMethodCommand : IRequest<Response<Guid>>
    {
        public string? Description { get; set; }
    }

    public class CreatePaymentMethodCommandHandler : IRequestHandler<CreatePaymentMethodCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePaymentMethodCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<Guid>> Handle(CreatePaymentMethodCommand command, CancellationToken cancellationToken)
        {
            var newPaymentMethod = _mapper.Map<PaymentMethod>(command);

            await _unitOfWork.Repository<PaymentMethod>().AddAsync(newPaymentMethod);

            newPaymentMethod.AddDomainEvent(new PaymentMethodCreateEvent(newPaymentMethod));

            await _unitOfWork.Save(cancellationToken);

            return new Response<Guid>(newPaymentMethod.Id);
        }

    }
}
