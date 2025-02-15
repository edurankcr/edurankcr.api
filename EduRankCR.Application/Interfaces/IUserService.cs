using EduRankCR.Application.DTOs;

namespace EduRankCR.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(UserCreateDto userCreateDto);
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<UserDto> UpdateUserAsync(Guid id, UserUpdateDto userUpdateDto);
        Task<UserDto> DeleteUserAsync(Guid id);
    }
}