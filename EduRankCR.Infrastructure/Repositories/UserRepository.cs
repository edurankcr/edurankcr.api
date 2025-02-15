using System.Data;
using Dapper;
using EduRankCR.Application.DTOs;
using EduRankCR.Application.Interfaces;
using EduRankCR.Domain.Entities;
using EduRankCR.Infrastructure.Data;

namespace EduRankCR.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UserRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        
        public async Task<User> CreateUserAsync(UserCreateDto userCreateDto)
        {
            using IDbConnection connection = _connectionFactory.CreateConnection();
            var parameters = new
            {
                userCreateDto.Name,
                userCreateDto.LastName,
                userCreateDto.Username,
                userCreateDto.Email,
                userCreateDto.EmailConfirmed,
                userCreateDto.Role,
                userCreateDto.Birthdate,
                userCreateDto.Password,
                userCreateDto.AvatarUrl,
                userCreateDto.Biography
            };
            return (await connection.QueryFirstOrDefaultAsync<User>(
                "sp_CreateUser", parameters, commandType: CommandType.StoredProcedure)) ?? throw new Exception();
        }
        
        public async Task<List<User>> GetAllUsersAsync()
        {
            using IDbConnection connection = _connectionFactory.CreateConnection();
            return (await connection.QueryAsync<User>("sp_GetAllUsers", commandType: CommandType.StoredProcedure)).ToList() ?? throw new Exception();
        }
        
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            using IDbConnection connection = _connectionFactory.CreateConnection();
            var parameters = new { UserId = id };
            return (await connection.QueryFirstOrDefaultAsync<User>(
                "sp_GetUserById", parameters, commandType: CommandType.StoredProcedure)) ?? throw new Exception();
        }
        
        public async Task<User> UpdateUserAsync(Guid id, UserUpdateDto userUpdateDto)
        {
            using IDbConnection connection = _connectionFactory.CreateConnection();
            var parameters = new
            {
                UserId = id,
                userUpdateDto.Name,
                userUpdateDto.LastName,
                userUpdateDto.Username,
                userUpdateDto.Email,
                userUpdateDto.EmailConfirmed,
                userUpdateDto.Birthdate,
                userUpdateDto.Role,
                userUpdateDto.Status,
                userUpdateDto.AvatarUrl,
                userUpdateDto.Biography
            };
            return (await connection.QueryFirstOrDefaultAsync<User>(
                "sp_UpdateUser", parameters, commandType: CommandType.StoredProcedure)) ?? throw new Exception();
        }
        
        public async Task<User> DeleteUserAsync(Guid id)
        {
            using IDbConnection connection = _connectionFactory.CreateConnection();
            var parameters = new { UserId = id };
            return (await connection.QueryFirstOrDefaultAsync<User>(
                "sp_DeleteUser", parameters, commandType: CommandType.StoredProcedure)) ?? throw new Exception();
        }
    }
}