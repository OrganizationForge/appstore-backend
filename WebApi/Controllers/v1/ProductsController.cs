using Application.DTOs;
using Application.Features.Language.Queries.GetLanguageById;
using Application.Features.ProductComments.Commands.CreateCommentCommand;
using Application.Features.Products.Commands.CreateProductCommand;
using Application.Features.Products.Queries.GetAllProducts;
using Application.Features.Products.Queries.GetProductById;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductsController : BaseApiController
    {
        [HttpGet]
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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
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
        public async Task<IActionResult> Post( [FromBody]CreateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        [Route("comments")]
        public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
