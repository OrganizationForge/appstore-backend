using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Features.Authenticate.Commands.AuthenticateCommand;
using Application.Features.Authenticate.Commands.RefreshTokenCommand;
using Application.Features.Authenticate.Commands.RegisterCommand;
using Application.Features.Authenticate.Commands.RevokeTokenCommand;
using Application.Features.Authenticate.Queries;
using Application.Features.Authenticate.User;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Identity
{
    [ApiVersion("1.0")]
    public class AccountController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetListAsync(CancellationToken cancellationToken)
        //public Task<List<UserDetailsDto>> GetListAsync(CancellationToken cancellationToken)
        {
            //return _userService.GetListAsync(cancellationToken);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id, CancellationToken cancellationToken)
        //public Task<UserDetailsDto> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return Ok();
            //return _userService.GetAsync(id, cancellationToken);
        }

        [HttpGet("{id}/roles")]
        public async Task<IActionResult> GetRolesAsync(string id, CancellationToken cancellationToken)
        //public Task<List<UserRoleDto>> GetRolesAsync(string id, CancellationToken cancellationToken)
        {
            //return _userService.GetRolesAsync(id, cancellationToken);
            return Ok();
        }

        [HttpPost("{id}/roles")]
        public async Task<IActionResult> AssignRolesAsync(string id, CancellationToken cancellationToken)
        //public async Task<IActionResult> AssignRolesAsync(string id, UserRolesRequest request, CancellationToken cancellationToken)
        {
            //return _userService.AssignRolesAsync(id, request, cancellationToken);
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            return Ok(await Mediator.Send(new RegisterCommand
            {
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Email = request.Email,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,
                UserName = request.UserName,
                Origin = GetOriginFromRequest()
                //Origin = Request.Headers["origin"]
            }));
        }


        //[HttpPost("self-register")]
        //[TenantIdHeader]
        //[AllowAnonymous]
        //[OpenApiOperation("Anonymous user creates a user.", "")]
        //[ApiConventionMethod(typeof(FSHApiConventions), nameof(FSHApiConventions.Register))]
        //public Task<string> SelfRegisterAsync(CreateUserRequest request)
        //{
        //    // TODO: check if registering anonymous users is actually allowed (should probably be an appsetting)
        //    // and return UnAuthorized when it isn't
        //    // Also: add other protection to prevent automatic posting (captcha?)
        //    return _userService.CreateAsync(request, GetOriginFromRequest());
        //}

        [HttpPost("{id}/toggle-status")]
        public async Task<IActionResult> ToggleStatusAsync(string id, CancellationToken cancellationToken)
        //public async Task<IActionResult> ToggleStatusAsync(string id, ToggleUserStatusRequest request, CancellationToken cancellationToken)
        {
            //if (id != request.UserId)
            //{
            //    return BadRequest();
            //}

            //await _userService.ToggleStatusAsync(request, cancellationToken);
            return Ok();
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmailAsync([FromQuery] string tenant, [FromQuery] string userId, [FromQuery] string code, CancellationToken cancellationToken)
        {
            //return _userService.ConfirmEmailAsync(userId, code, tenant, cancellationToken);
            return Ok();
        }

        [HttpGet("confirm-phone-number")]
        public async Task<IActionResult> ConfirmPhoneNumberAsync([FromQuery] string userId, [FromQuery] string code)
        {
            //return _userService.ConfirmPhoneNumberAsync(userId, code);
            return Ok();
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPasswordAsync()
        //public async Task<IActionResult> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            //return _userService.ForgotPasswordAsync(request, GetOriginFromRequest());
            return Ok();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync()
        //public async Task<IActionResult> ResetPasswordAsync(ResetPasswordRequest request)
        {
            //return _userService.ResetPasswordAsync(request);
            return Ok();

        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            var result = await Mediator.Send(new AuthenticateCommand
            {
                Email = request.Email,
                Password = request.Password,
                IpAddress = GenerateIpAddress()
            });
            SetRefreshTokenInCookie(result.Data.RefreshToken, (DateTime)result.Data.RefreshTokenExpiration);
            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken()
        {
            var result = await Mediator.Send(new RefreshTokenCommand
            {
                RefreshToken = RecuperarRefreshToken(),
                IpAddress = GenerateIpAddress()
            });
            SetRefreshTokenInCookie(result.Data.RefreshToken, (DateTime)result.Data.RefreshTokenExpiration);
            return Ok(result);
            //return Ok(await Mediator.Send(new RefreshTokenCommand
            //{
            //    AccessToken = request.AccessToken,
            //    RefreshToken = request.RefreshToken,
            //    IpAddress = GenerateIpAddress()
            //}));
        }

        [HttpGet]
        [Route("revoke-token")]
        public async Task<IActionResult> RevokeToken()
        {
            var result = await Mediator.Send(new RevokeRefreshtokenCommand
            {
                RefreshToken = RecuperarRefreshToken(),
                IpAddress = GenerateIpAddress()
            });
            return Ok(result);
        }


        [HttpGet("current")]
        public async Task<IActionResult> GetCurrent()
        {
            return Ok(await Mediator.Send(new GetUserByIdQuery()));
        }

      //  [HttpGet]
      //  public Task<UserEnvelope> GetCurrent(CancellationToken cancellationToken) =>
      //mediator.Send(
      //    new Details.Query(currentUserAccessor.GetCurrentUsername() ?? "<unknown>"),
      //    cancellationToken
      //);

        private string GetOriginFromRequest() => $"{Request.Scheme}://{Request.Host.Value}{Request.PathBase.Value}";
        private string GenerateIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        private void SetRefreshTokenInCookie(string refreshToken, DateTime expiration)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = expiration,
                HttpOnly = true,
                Secure = true,
                Path = "/",
                SameSite = SameSiteMode.Lax
                //SameSite = SameSiteMode.Lax
            };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }

        private string RecuperarRefreshToken()
        {
            //recupero el refresh token de la cookie
            string cookiesHeader = Request.Headers["Cookie"];
            Request.Cookies.TryGetValue("refreshToken", out string refreshToken);

            if (refreshToken == null)
                throw new ApiException("Token no encontrado");

            //refreshToken = request ?? refreshToken;
            return refreshToken;
        }
    }
}
