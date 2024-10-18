using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniKFCStore.DTO;
using MiniKFCStore.Models;
using MiniKFCStore.Services.Interface;

namespace MiniKFCStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userService.Authenticate(loginDto.Username, loginDto.Password);
            if (user == null)
                return Unauthorized();

            var token = _userService.GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, User user)
        {
            if (id != user.Id) return BadRequest();
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
