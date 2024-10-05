using Application.Common.Interfaces;
using Application.Common.Wrappers;
using MediatR;

namespace Application.Features.Authenticate.Commands.RevokeTokenCommand
{
    public class RevokeRefreshtokenCommand : IRequest<Response<bool>>
    {
         
        public string RefreshToken { get; set; }
        public string? IpAddress { get; set; }
    }

    public class RevokeRefreshtokenCommandHandler : IRequestHandler<RevokeRefreshtokenCommand, Response<bool>>
    {
        private readonly IAccountService _accountService;

        public RevokeRefreshtokenCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Response<bool>> Handle(RevokeRefreshtokenCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.RevokeTokenAsync(request.RefreshToken, request.IpAddress);
        }



    }
}
