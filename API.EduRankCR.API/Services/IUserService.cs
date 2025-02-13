using API.EduRankCR.Shared.DTOs;
using API.EduRankCR.Shared.Responses;

namespace API.EduRankCR.API.Services
{
    public interface IUserService
    {
        Task<ApiResponse<NewUserResponseDTO>> CreateUserAsync(NewUserRequestDTO userDTO);
        Task<ApiResponse<NewUserResponseDTO?>> GetUserByIdAsync(Guid id);
    }
}
