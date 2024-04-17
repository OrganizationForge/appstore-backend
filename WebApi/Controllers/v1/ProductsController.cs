using Application.Features.Products.Commands.CreateProductCommand;
using Application.Features.Products.Queries;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get(PaginationProductParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                ProductName = filter.ProductName,
                Description = filter.Description,
                Rating = filter.Rating,
                CategoryId = filter.CategoryId,
                BrandId = filter.BrandId,
                MinPrice = filter.MinPrice,
                MaxPrice = filter.MaxPrice
            }));
        }

        [HttpPost]
        public async Task<IActionResult> Post( [FromBody]CreateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
