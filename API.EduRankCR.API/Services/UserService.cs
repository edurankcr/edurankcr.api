using API.EduRankCR.Shared.DTOs;
using API.EduRankCR.API.Repositories;
using API.EduRankCR.Shared.Responses;

namespace API.EduRankCR.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApiResponse<NewUserResponseDTO>> CreateUserAsync(
            NewUserRequestDTO userDTO
        )
        {
            return await _userRepository.CreateUserAsync(userDTO);
        }

        public async Task<ApiResponse<NewUserResponseDTO?>> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }
    }
}
