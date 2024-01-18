using Application.Features.Authenticate.Commands.AuthenticateCommand;
using Application.Features.Authenticate.Commands.RegisterCommand;
using Application.Features.Authenticate.User;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        [HttpPost("Authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await Mediator.Send(new AuthenticateCommand
            {
                Email = request.Email,
                Password = request.Password,
                IpAddress = GenerateIpAddress()
            }));
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            return Ok(await Mediator.Send(new RegisterCommand
            {
                Nombre= request.Nombre,
                Apellido= request.Apellido,
                Email = request.Email,
                Password = request.Password,
                ConfirmPassword= request.ConfirmPassword,
                UserName= request.UserName,
                Origin = Request.Headers["origin"]
            }));
        }

        private string GenerateIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
