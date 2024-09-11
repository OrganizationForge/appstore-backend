using Application.Features.Shipping.Commands.CreateShippingMethod;
using Application.Features.Shipping.Queries.GetAllShippingMethods;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ShippingController : BaseApiController
    {
        [HttpGet]
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
