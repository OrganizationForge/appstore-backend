using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetListAsync(CancellationToken cancellationToken)
        {
            //return _roleService.GetListAsync(cancellationToken);
            return Ok("Ok");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            //return _roleService.GetByIdAsync(id);
            return Ok("Ok");

        }

        [HttpGet("{id}/permissions")]
        public async Task<IActionResult> GetByIdWithPermissionsAsync(string id, CancellationToken cancellationToken)
        {
            //return _roleService.GetByIdWithPermissionsAsync(id, cancellationToken);
            return Ok("Ok");

        }

        [HttpPut("{id}/permissions")]
        public async Task<IActionResult> UpdatePermissionsAsync(string id, CancellationToken cancellationToken)
        //public async Task<IActionResult> UpdatePermissionsAsync(string id, UpdateRolePermissionsRequest request, CancellationToken cancellationToken)
        {
            //if (id != request.RoleId)
            //{
            //    return BadRequest();
            //}

            //return Ok(await _roleService.UpdatePermissionsAsync(request, cancellationToken));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterRoleAsync()
        //public async Task<IActionResult> RegisterRoleAsync(CreateOrUpdateRoleRequest request)
        {
            //return _roleService.CreateOrUpdateAsync(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            //return _roleService.DeleteAsync(id);
            return Ok();
        }
    }
}
