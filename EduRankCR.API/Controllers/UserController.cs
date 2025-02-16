using EduRankCR.Application.DTOs.Request;
using EduRankCR.Application.DTOs.Response;
using EduRankCR.Application.Interfaces;
using EduRankCR.Application.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace EduRankCR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<RequestMainUserIdDto> _idValidator;
        private readonly IValidator<RequestUserCreateDto> _createValidator;
        private readonly IValidator<RequestUserUpdateDto> _updateValidator;

        public UserController(IUserService userService, IValidator<RequestMainUserIdDto> idValidator, IValidator<RequestUserCreateDto> createValidator, IValidator<RequestUserUpdateDto> updateValidator)
        {
            _userService = userService;
            _idValidator = idValidator;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] RequestUserCreateDto requestUserCreateDto)
        {
            var validationResult = await _createValidator.ValidateAsync(requestUserCreateDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            ResponseUserDto user = await _userService.CreateUserAsync(requestUserCreateDto);
            return Ok(ApiResponse<ResponseUserDto>.Success(user, "USER_CREATED"));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            List<ResponseUserDto> users = await _userService.GetAllUsersAsync();
            return Ok(ApiResponse<List<ResponseUserDto>>.Success(users, "USERS_FOUND"));
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var validationResult = await _idValidator.ValidateAsync(new RequestMainUserIdDto { Id = id });
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            ResponseUserDto user = await _userService.GetUserByIdAsync(id);
            return Ok(ApiResponse<ResponseUserDto>.Success(user, "USER_FOUND"));
        }
        
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] RequestUserUpdateDto requestUserUpdateDto)
        {
            var validationResult = await Task.WhenAll(
                _idValidator.ValidateAsync(new RequestMainUserIdDto { Id = id }),
                _updateValidator.ValidateAsync(requestUserUpdateDto)
            );
            if (!validationResult[0].IsValid || !validationResult[1].IsValid)
            {
                throw new ValidationException(validationResult.SelectMany(x => x.Errors));
            }
            await _userService.UpdateUserAsync(id, requestUserUpdateDto);
            return Ok(ApiResponse.Empty("USER_UPDATED"));
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var validationResult = await _idValidator.ValidateAsync(new RequestMainUserIdDto { Id = id });
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            await _userService.DeleteUserAsync(id);
            return Ok(ApiResponse.Empty("USER_DELETED"));
        }
    }
}