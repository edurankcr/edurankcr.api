using API.EduRankCR.Shared.DTOs;
using API.EduRankCR.Shared.Responses;

namespace API.EduRankCR.API.Repositories
{
    public interface IUserRepository
    {
        Task<ApiResponse<NewUserResponseDTO>> CreateUserAsync(NewUserRequestDTO userDTO);
        Task<ApiResponse<NewUserResponseDTO>> GetUserByIdAsync(Guid id);
    }
}
