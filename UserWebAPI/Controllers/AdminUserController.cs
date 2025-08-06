using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserWebAPI.Models;
using UserWebAPI.Repositories;

namespace UserWebAPI.Controllers
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminUserController : ControllerBase
    {
        private readonly IAdminUserRepository _repo;

        public AdminUserController(IAdminUserRepository repo)
        {
            _repo = repo;
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser(string name,[FromBody] UpdateUserRequest request)
        {
            var updated = await _repo.UpdateUserByNameAsync(name,request);
            if (updated == null)
                return NotFound("User not found with the given name.");

            var activity = new UserActivity
            {
                ActivityID = Guid.NewGuid(),
                UserID = updated.UserID,
                Activity = "User Updated",
                Role = updated.Role,
                Timestamp = DateTime.UtcNow
            };

            await _repo.LogActivityAsync(activity);
            return Ok("User updated successfully.");
        }
    }
}
