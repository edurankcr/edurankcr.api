using AutoMapper;
using EduRankCR.Application.DTOs;
using EduRankCR.Application.Interfaces;
using EduRankCR.Domain.Entities;
using EduRankCR.Domain.Exceptions;

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
        
        public async Task<UserDto> CreateUserAsync(UserCreateDto userCreateDto)
        {
            User newUser = _mapper.Map<User>(userCreateDto);
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(userCreateDto.Password);
            User createdUser = await _userRepository.CreateUserAsync(newUser);
            return _mapper.Map<UserDto>(createdUser);
        }
        
        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            List<User> users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<List<UserDto>>(users);
        }
        
        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            User user = await _userRepository.GetUserByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }
        
        public async Task<UserDto> UpdateUserAsync(Guid id, UserDto userDto)
        {
            User updatedUser = _mapper.Map<User>(userDto);
            updatedUser.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            User user = await _userRepository.UpdateUserAsync(id, updatedUser);
            return _mapper.Map<UserDto>(user);
        }
        
        public async Task<UserDto> DeleteUserAsync(Guid id)
        {
            User deletedUser = await _userRepository.DeleteUserAsync(id);
            return _mapper.Map<UserDto>(deletedUser);
        }
    }
}