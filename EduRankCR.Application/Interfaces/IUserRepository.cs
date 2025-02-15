using EduRankCR.Application.DTOs;
using EduRankCR.Domain.Entities;

namespace EduRankCR.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(RequestUserCreateDto requestUserCreateDto);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> UpdateUserAsync(Guid id, RequestUserUpdateDto requestUserUpdateDto);
        Task<User> DeleteUserAsync(Guid id);
    }
}