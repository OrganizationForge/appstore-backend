using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PersonalController : BaseApiController
    {
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfileAsync(CancellationToken cancellationToken)
        //public async Task<ActionResult<UserDetailsDto>> GetProfileAsync(CancellationToken cancellationToken)
        {
            //return User.GetUserId() is not { } userId || string.IsNullOrEmpty(userId)
            //    ? Unauthorized()
            //    : Ok(await _userService.GetAsync(userId, cancellationToken));

            return Ok();
        }

        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfileAsync()
        //public async Task<ActionResult> UpdateProfileAsync(UpdateUserRequest request)
        {
            //if (User.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
            //{
            //    return Unauthorized();
            //}

            //await _userService.UpdateAsync(request, userId);
            return Ok();
        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePasswordAsync()
        //public async Task<ActionResult> ChangePasswordAsync(ChangePasswordRequest model)
        {
            //if (User.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
            //{
            //    return Unauthorized();
            //}

            //await _userService.ChangePasswordAsync(model, userId);
            return Ok();
        }

        [HttpGet("permissions")]
        public async Task<ActionResult<List<string>>> GetPermissionsAsync(CancellationToken cancellationToken)
        {
            //return User.GetUserId() is not { } userId || string.IsNullOrEmpty(userId)
            //    ? Unauthorized()
            //    : Ok(await _userService.GetPermissionsAsync(userId, cancellationToken));

            return Ok();
        }

        [HttpGet("roles")]
        public async Task<ActionResult<List<string>>> GetRolesAsync(CancellationToken cancellationToken)
        {
            //return User.GetUserId() is not { } userId || string.IsNullOrEmpty(userId)
            //    ? Unauthorized()
            //    : Ok(await _userService.GetPermissionsAsync(userId, cancellationToken));

            return Ok();
        }

        [HttpGet("logs")]
        public async Task<IActionResult> GetLogsAsync()
        //public Task<List<AuditDto>> GetLogsAsync()
        {
            //return Mediator.Send(new GetMyAuditLogsRequest());
            return Ok();
        }
    }
}
