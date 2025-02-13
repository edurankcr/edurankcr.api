using API.EduRankCR.API.Services;
using API.EduRankCR.Shared.DTOs;
using API.EduRankCR.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.EduRankCR.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] NewUserRequestDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(m => m.Value != null && m.Value.Errors.Any())
                    .ToDictionary(
                        m => m.Key,
                        m => m.Value!.Errors.Select(e => e.ErrorMessage).ToList()
                    );

                return BadRequest(
                    ApiResponse<object>.ErrorResponse(
                        "VALIDATION_ERROR",
                        errors.SelectMany(e => e.Value).ToList()
                    )
                );
            }

            var response = await _userService.CreateUserAsync(userDTO);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return CreatedAtAction(nameof(GetUserById), new { id = response.Data?.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var response = await _userService.GetUserByIdAsync(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
