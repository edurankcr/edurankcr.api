using EduRankCR.Application.DTOs;
using EduRankCR.Application.Interfaces;
using EduRankCR.Domain.Entities;
using EduRankCR.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduRankCR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userCreateDto)
        {
            try
            {
                UserDto user = await _userService.CreateUserAsync(userCreateDto);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                List<UserDto> users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                UserDto user = await _userService.GetUserByIdAsync(id);
                return Ok(user);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
        
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserDto userDto)
        {
            try
            {
                UserDto user = await _userService.UpdateUserAsync(id, userDto);
                return Ok(user);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}