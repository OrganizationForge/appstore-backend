using Application.DTOs;
using Application.Features.Language.Queries.GetLanguageById;
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
        public async Task<IActionResult> Post([FromBody] CreateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        private async Task<ICollection<FileUpload>> ProcessImageFiles(IFormFileCollection files)
        {
            var productFiles = new List<FileUpload>();

            foreach (var file in files)
            {
                using (var stream = file.OpenReadStream())
                {
                    // Convertir el archivo en una matriz de bytes
                    using (var memoryStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memoryStream);
                        var imageBytes = memoryStream.ToArray();

                        // Crear un objeto ImageDTO
                        var imageDto = new FileUpload
                        {
                            ImageName = file.FileName,
                            ImageBytes = imageBytes.ToString()
                        };

                        productFiles.Add(imageDto);
                    }
                }
            }

            return productFiles;
        }

        //public async Task<IActionResult> AsyncUpload(IFormFile myFile)
        //{
        //    // Specifies the target location for the uploaded files
        //    string targetLocation = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
        //    try
        //    {
        //        if (!Directory.Exists(targetLocation))
        //            Directory.CreateDirectory(targetLocation);

        //        using (var fileStream = System.IO.File.Create(Path.Combine(targetLocation, myFile.FileName)))
        //        {
        //            myFile.CopyTo(fileStream);
        //        }
        //    }
        //    catch
        //    {
        //        Response.StatusCode = 400;
        //    }
        //    byte[] fileBytes = await myFile.GetBytes();
        //    return new ContentResult() { Content = Convert.ToBase64String(fileBytes) };
        //}
    }
}
