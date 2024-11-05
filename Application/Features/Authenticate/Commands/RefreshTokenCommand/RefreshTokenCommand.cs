using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Application.Features.Authenticate.User;
using MediatR;

namespace Application.Features.Authenticate.Commands.RefreshTokenCommand
{
    public class RefreshTokenCommand : IRequest<Response<AuthenticationResponse>>
    {
        public string RefreshToken { get; set; }
        public string? IpAddress { get; set; }
    }

    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, Response<AuthenticationResponse>>
    {
        private readonly IAccountService _accountService;

        public RefreshTokenCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Response<AuthenticationResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.RefreshTokenAsync(request.RefreshToken, request.IpAddress);
        }



    }
}
