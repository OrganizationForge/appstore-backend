﻿using Application.Features.Shippings.Commands.CreateShippingMethod;
using Application.Features.Shippings.Queries.GetAllShippingMethods;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize]
    public class ShippingController : BaseApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllShippingMethodsQuery()));
        }

        [HttpPost]

        public async Task<IActionResult> Post(CreateShippingMethodCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
