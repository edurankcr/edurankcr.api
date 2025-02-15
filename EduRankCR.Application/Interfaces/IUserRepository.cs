using EduRankCR.Domain.Entities;

namespace EduRankCR.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> UpdateUserAsync(Guid id, User user);
        Task<User> DeleteUserAsync(Guid id);
    }
}