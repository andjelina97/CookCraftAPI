using CookCraft.Domain.Dtos;
using CookCraft.Repositories.Entities;
using CookCraft.Repositories.Interfaces;
using CookCraft.Services.Interfaces;
using CookCraft.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CookCraft.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLogin)
        {
            var user = await _userService.Login(userLogin.Email, userLogin.Password);

            if (user == null)
                return StatusCode(401, "Invalid credentials."); // Unauthorized

            var token = _userService.GenerateJwtToken(user.Id);
            return Ok(new { Token = token }); // Return the token
        }

        [AllowAnonymous]
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] UserSignUpDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _userService.SignUp(userDto);

            if (!success)
                return StatusCode(500, "An error occurred during user registration."); // Internal Server Error

            return Ok("User registered successfully."); // OK
        }
    }
}
