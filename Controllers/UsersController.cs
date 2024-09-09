using BankingControlPanel.Models;
using BankingControlPanel.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankingControlPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdUser = await _userService.RegisterUser(user);
            return CreatedAtAction(nameof(Login), new { email = createdUser.Email }, createdUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var loggedInUser = await _userService.LoginUser(user.Email, user.Password);
            if (loggedInUser == null) return Unauthorized();
            return Ok(loggedInUser);
        }
    }
}
