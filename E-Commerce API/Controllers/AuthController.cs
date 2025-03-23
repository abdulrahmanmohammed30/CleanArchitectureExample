using Microsoft.AspNetCore.Mvc;
using E_Commerce_API.DTOs;
using Microsoft.AspNetCore.Identity;
using E_Commerce_Domain.Identity;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(UserManager<User> userManager, SignInManager<User> signInManager) : ControllerBase
    {

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User()
            {
                Email = registerDto.Email,
                FullName = registerDto.FullName,
                UserName = registerDto.UserName,
            };

            var result = await userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded == false)
            {
                return BadRequest("User registration failed.");
            }

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var user = await userManager.FindByNameAsync(loginDto.UserName);

            //if (user == null)
            //{
            //    return Problem("Invalid username or password", statusCode: 400);
            //}

            // Generate Token 

            var result = await signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);

            if (result.Succeeded == false)
            {
                return Unauthorized();
            }

            return Ok(new { Token = "token" });
        }
    }
}
