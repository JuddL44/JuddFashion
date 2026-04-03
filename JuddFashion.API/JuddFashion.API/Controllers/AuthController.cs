using JuddFashion.API.Models.DTOs;
using JuddFashion.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace JuddFashion.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseDTO>> Register(RegisterDTO registerDto)
        {
            var result = await _authService.Register(registerDto);
            if (result == null)
            {
                return BadRequest(new { message = "Username or email already exists." });
            }
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDTO>> Login(LoginDTO loginDto)
        {
            var result = await _authService.Login(loginDto);
            if (result == null)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }
            return Ok(result);
        }

        [HttpGet("me")]
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            // Placeholder
            return Ok(new { message = " Protected Route " });
        }
    }
}