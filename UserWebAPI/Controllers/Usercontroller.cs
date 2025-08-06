using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UserWebAPI.Helpers;
using UserWebAPI.Models;
using UserWebAPI.Repositories;
using UserWebAPI.DTOs;


namespace UserWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }
        // private readonly JwtTokenGenerator _jwtTokenGenerator;

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userRole = User.FindFirstValue(ClaimTypes.Role);
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            if (string.IsNullOrEmpty(userRole) || string.IsNullOrEmpty(userEmail))
                return Unauthorized("Invalid token or missing claims.");

            if (userRole.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                var allUsers = await _repo.GetAllAsync();
                return Ok(allUsers);
            }
            else
            {
                var user = await _repo.GetByEmailAsync(userEmail);

                if (user == null)
                    return NotFound("User not found.");

                return Ok(user);
            }
        }


        [HttpPost]
            public async Task<IActionResult> Create(User user)
            {
                if (await _repo.EmailExistsAsync(user.Email))
                {
                    return BadRequest(new { message = "Email already exists" });
                }

                var created = await _repo.CreateAsync(user);
                return CreatedAtAction(nameof(Get), new { id = created.UserID }, created);
            }
        }
    }
