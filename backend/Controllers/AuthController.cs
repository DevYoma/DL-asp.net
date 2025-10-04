using Microsoft.AspNetCore.Mvc;
using DigitalLogbookAPI.DTOs;
using System.Threading.Tasks;
using Supabase;
using Supabase.Postgrest.Models;
using System;

namespace DigitalLogbookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly SupabaseService _supabaseService;

        public AuthController()
        {
            _supabaseService = new SupabaseService();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            try
            {
                var client = _supabaseService.GetClient();

                var authResponse = await client.Auth.SignUp(dto.Email, dto.Password);

                if (authResponse.User == null)
                    return BadRequest(new { message = "Registration failed. User may already exist." });

                return Ok(new { message = "User registered successfully!", user = authResponse.User });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            try
            {
                var client = _supabaseService.GetClient();
                var session = await client.Auth.SignIn(dto.Email, dto.Password);

                if (session.User == null)
                    return Unauthorized(new { message = "Invalid email or password." });

                return Ok(new { message = "Login successful!", user = session.User, access_token = session.AccessToken });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
