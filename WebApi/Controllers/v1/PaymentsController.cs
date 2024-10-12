using Application.Features.Payments.Commands.CreatePaymentCommand;
using Application.Features.Payments.Commands.CreatePaymentMethodCommand;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize]
    public class PaymentsController : BaseApiController
    {

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        [Route("methods")]
        public async Task<IActionResult> CreatePaymentMethod([FromBody] CreatePaymentMethodCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }


}
