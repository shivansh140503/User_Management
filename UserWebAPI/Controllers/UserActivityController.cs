using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserWebAPI.Models;
using UserWebAPI.Repositories;
using UserWebAPI.Repository;
using UserWebAPI.DTOs;

namespace UserWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserActivityController : ControllerBase
    {
        private readonly UserActivityRepo _activityRepo;

        public UserActivityController(UserActivityRepo activityRepo)
        {
            _activityRepo = activityRepo;
        }

        //[HttpGet]
        //[Authorize]
        //public async Task<ActionResult<IEnumerable<UserActivity>>> GetAllActivitiesAsync()
        //{
        //    var userRole = User.FindFirstValue(ClaimTypes.Role);
        //    var userEmail = User.FindFirstValue(ClaimTypes.Email);

        //    if (string.IsNullOrWhiteSpace(userRole) || string.IsNullOrWhiteSpace(userEmail))
        //        return Unauthorized("Invalid token or missing claims.");

        //    if (!userRole.Equals("admin", StringComparison.OrdinalIgnoreCase))
        //        return Forbid("Only admin can access all user activities.");

        //    var activities = await _activityRepo.GetAllActivitiesAsync();
        //    return Ok(activities);
        //}

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAdminActivity()
        {
            var activities = await _activityRepo.GetAdminActivityLogAsync();
            return Ok(activities);
        }
    }
}
