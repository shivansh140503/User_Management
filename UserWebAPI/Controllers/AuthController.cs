using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserWebAPI.Helpers;
using UserWebAPI.Models;
using UserWebAPI.Repositories;

namespace UserWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public AuthController(IUserRepository userRepository, JwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null || user.Password != request.Password)
                return Unauthorized("Invalid email or password.");

            var token = _jwtTokenGenerator.GenerateToken(user);
            return Ok(new
            {
                Token = token,
                role = user.Role,
                email = user.Email
            });


        }

    }
}
