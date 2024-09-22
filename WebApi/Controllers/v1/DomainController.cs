using Application.Features.Availavilities.Queries.GetAllAvailavilities;
using Application.Features.QuantityTypes.Queries.GetAllQuentityTypes;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DomainController : BaseApiController
    {
        [HttpGet("quantity-types")]
        public async Task<IActionResult> GetAllQuantityTypes()
        {
            return Ok(await Mediator.Send(new GetAllQuentityTypesQuery()));
        }


        //[HttpPost]

        //public async Task<IActionResult> Post(CreateBrandCommand command)
        //{
        //    return Ok(await Mediator.Send(command));
        //}

        [HttpGet("availabilities")]
        public async Task<IActionResult> GetAllAvailavilities()
        {
            return Ok(await Mediator.Send(new GetAllAvailavilitiesQuery()));
        }
    }
}
