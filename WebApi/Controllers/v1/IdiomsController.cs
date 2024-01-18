using Application.Features.Language.Commands.CreateLanguageCommand;
using Application.Features.Language.Queries.GetAllLanguages;
using Application.Features.Language.Queries.GetLanguageById;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class IdiomsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationIdiomParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllIdiomsQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                Code = filter.Code,
                Description = filter.Description
            }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetIdiomByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateIdiomCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
