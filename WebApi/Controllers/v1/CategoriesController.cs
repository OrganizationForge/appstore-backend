using Application.Features.Categories.Commands.CreateCategoryCommand;
using Application.Features.Categories.Queries;
using Application.Features.Products.Commands.CreateProductCommand;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize]
    public class CategoriesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllCategoriesQuery {}));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
