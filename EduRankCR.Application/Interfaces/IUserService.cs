using EduRankCR.Application.DTOs.Response;
using EduRankCR.Application.DTOs.Request;

namespace EduRankCR.Application.Interfaces
{
    public interface IUserService
    {
        Task<ResponseUserDto> CreateUserAsync(RequestUserCreateDto requestUserCreateDto);
        Task<List<ResponseUserDto>> GetAllUsersAsync();
        Task<ResponseUserDto> GetUserByIdAsync(Guid id);
        Task<ResponseUserDto> UpdateUserAsync(Guid id, RequestUserUpdateDto requestUserUpdateDto);
        Task<ResponseUserIdDto> DeleteUserAsync(Guid id);
    }
}