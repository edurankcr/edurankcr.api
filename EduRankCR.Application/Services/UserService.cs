using AutoMapper;
using EduRankCR.Application.DTOs;
using EduRankCR.Application.Interfaces;
using EduRankCR.Domain.Entities;

namespace EduRankCR.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        
        public async Task<ResponseUserDto> CreateUserAsync(RequestUserCreateDto requestUserCreateDto)
        {
            requestUserCreateDto.Password = BCrypt.Net.BCrypt.HashPassword(requestUserCreateDto.Password);
            User createdUser = await _userRepository.CreateUserAsync(requestUserCreateDto);
            return _mapper.Map<ResponseUserDto>(createdUser);
        }
        
        public async Task<List<ResponseUserDto>> GetAllUsersAsync()
        {
            List<User> users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<List<ResponseUserDto>>(users);
        }
        
        public async Task<ResponseUserDto> GetUserByIdAsync(Guid id)
        {
            User user = await _userRepository.GetUserByIdAsync(id);
            return _mapper.Map<ResponseUserDto>(user);
        }
        
        public async Task<ResponseUserDto> UpdateUserAsync(Guid id, RequestUserUpdateDto requestUserUpdateDto)
        {
            User user = await _userRepository.UpdateUserAsync(id, requestUserUpdateDto);
            return _mapper.Map<ResponseUserDto>(user);
        }
        
        public async Task<ResponseUserIdDto> DeleteUserAsync(Guid id)
        {
            User deletedUser = await _userRepository.DeleteUserAsync(id);
            return _mapper.Map<ResponseUserIdDto>(deletedUser);
        }
    }
}