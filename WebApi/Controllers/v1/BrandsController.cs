using Application.Features.Brands.Commands.CreateBrandCommand;
using Application.Features.Brands.Commands.DeleteBrandByIdCommand;
using Application.Features.Brands.Queries;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize]
    public class BrandsController : BaseApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllBrandsQuery()));
        }

        [HttpPost]

        public async Task<IActionResult> Post(CreateBrandCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteBrandByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
