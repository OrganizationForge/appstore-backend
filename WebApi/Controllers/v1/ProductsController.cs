using Application.Features.ProductComments.Commands.CreateCommentCommand;
using Application.Features.Products.Commands.CreateProductCommand;
using Application.Features.Products.Commands.ExportProductCommand;
using Application.Features.Products.Commands.UpdateProductCommand;
using Application.Features.Products.Queries.GetAllProducts;
using Application.Features.Products.Queries.GetProductById;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize]
    public class ProductsController : BaseApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationProductParameters filter)
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

        [HttpGet("{id:Guid}")]
        [AllowAnonymous]

        public async Task<IActionResult> GetAsync(Guid id)
        {
            return Ok(await Mediator.Send(new GetProductByIdQuery { Id = id }));
        }

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody]CreateProductCommand command)
        //{
        //    // Procesar los archivos de imagen
        //    var productFiles = await ProcessImageFiles(command.ProductFiles);

        //    // Actualizar el comando con los archivos procesados
        //    //command.ProductFiles = productFiles;

        //    // Continuar con el procesamiento del comando
        //    //return Ok(await Mediator.Send(command));
        //    return Ok(await Mediator.Send(command));
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("comments")]
        public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        [Route("export")]
        public async Task<FileResult> ExportAsync([FromBody] ExportProductCommand command)
        {
            var result = await Mediator.Send(command);
            return File(result, "application/octet-stream", "ProductExports");
        }

    }
}
