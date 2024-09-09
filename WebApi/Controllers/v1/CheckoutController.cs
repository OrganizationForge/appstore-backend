﻿using Application.Features.Payments.Commands.CreatePaymentCommand;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CheckoutController : BaseApiController
    {

        [HttpPost]
        [Route("Payments")]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


    }
}
