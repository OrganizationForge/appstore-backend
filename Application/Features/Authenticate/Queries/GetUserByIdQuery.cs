using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Application.Features.Authenticate.User;
using MediatR;

namespace Application.Features.Authenticate.Queries
{
    public class GetUserByIdQuery : IRequest<Response<AuthenticationResponse>>
    {

    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Response<AuthenticationResponse>>
    {
        private readonly IAccountService _accountService;

        public GetUserByIdQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Response<AuthenticationResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _accountService.GetUser();
        }
    }
}
