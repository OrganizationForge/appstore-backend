using Asp.Versioning;
using Fractions;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TenantsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        //public Task<List<TenantDto>> GetListAsync()
        {
            //return Mediator.Send(new GetAllTenantsRequest());
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        //public Task<TenantDto> GetAsync(string id)
        {
            //return Mediator.Send(new GetTenantRequest(id));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync()
        //public Task<string> CreateAsync(CreateTenantRequest request)
        {
            //return Mediator.Send(request);
            return Ok();
        }

        [HttpPost("{id}/activate")]
        public async Task<IActionResult> ActivateAsync(string id)
        {
            //return Mediator.Send(new ActivateTenantRequest(id));
            return Ok();
        }

        [HttpPost("{id}/deactivate")]
        public async Task<IActionResult> DeactivateAsync(string id)
        {
            //return Mediator.Send(new DeactivateTenantRequest(id));
            return Ok();
        }

        [HttpPost("{id}/upgrade")]
        public async Task<ActionResult> UpgradeSubscriptionAsync(string id)
        //public async Task<ActionResult<string>> UpgradeSubscriptionAsync(string id, UpgradeSubscriptionRequest request)
        {
            //return id != request.TenantId
            //    ? BadRequest()
            //    : Ok(await Mediator.Send(request));

            return Ok();
        }
    }
}
