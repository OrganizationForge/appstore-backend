using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Application.DTOs;
using AutoMapper;
using MediatR;

namespace Application.Features.Payments.Commands.CreatePaymentCommand
{
    public class CreatePaymentCommand : IRequest<Response<CreatePaymentResponse>>
    {
        public List<ProductItemDTO>? Products { get; set; }
        public UserDTO? User { get; set; }
        public string? SuccessUrl { get; set; }
        public string? FailureUrl { get; set; }
        public string? PendingUrl { get; set; }
        public string? NotificationUrl { get; set; }
        public string? StatementDescriptor { get; set; }
        public string? ExternalReference { get; set; }
        public bool Expires { get; set; }
        public DateTime? ExpirationDateFrom { get; set; }
        public DateTime? ExpirationDateTo { get; set; }
    }

    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Response<CreatePaymentResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPaymentService _paymentService;
        public CreatePaymentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IPaymentService paymentService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _paymentService = paymentService;
        }

        public async Task<Response<CreatePaymentResponse>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var paymentResponse = await _paymentService.CreatePaymentAsync(request);
            return new Response<CreatePaymentResponse>(paymentResponse);
        }
    }
}
