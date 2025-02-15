using EduRankCR.Application.DTOs;

namespace EduRankCR.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(UserCreateDto userCreateDto);
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<UserDto> UpdateUserAsync(Guid id, UserDto user);
        Task<UserDto> DeleteUserAsync(Guid id);
    }
}