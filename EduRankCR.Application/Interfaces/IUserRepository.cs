using EduRankCR.Application.DTOs;
using EduRankCR.Domain.Entities;

namespace EduRankCR.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(UserCreateDto userCreateDto);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> UpdateUserAsync(Guid id, UserUpdateDto userUpdateDto);
        Task<User> DeleteUserAsync(Guid id);
    }
}