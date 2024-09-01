using Asp.Versioning;
using Fractions;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DashboardController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        //public Task<StatsDto> GetAsync()
        {
            //return Mediator.Send(new GetStatsRequest());
            return Ok();
        }
    }
}
