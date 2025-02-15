﻿using System.Data;
using Dapper;
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
        
        public async Task<User> CreateUserAsync(User user)
        {
            using IDbConnection connection = _connectionFactory.CreateConnection();
            var parameters = new
            {
                user.Name,
                user.LastName,
                user.Username,
                user.Email,
                user.EmailConfirmed,
                user.Role,
                user.Birthdate,
                user.Password,
                user.AvatarUrl,
                user.Biography
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
            var parameters = new { Id = id };
            return await connection.QueryFirstOrDefaultAsync<User>(
                "sp_GetUserById", parameters, commandType: CommandType.StoredProcedure);
        }
        
        public async Task<User> UpdateUserAsync(Guid id, User user)
        {
            using IDbConnection connection = _connectionFactory.CreateConnection();
            var parameters = new
            {
                Id = id,
                user.Username,
                user.Password,
                user.Email,
                user.Role
            };
            return await connection.QueryFirstOrDefaultAsync<User>(
                "sp_UpdateUser", parameters, commandType: CommandType.StoredProcedure);
        }
        
        public async Task<User> DeleteUserAsync(Guid id)
        {
            using IDbConnection connection = _connectionFactory.CreateConnection();
            var parameters = new { Id = id };
            return await connection.QueryFirstOrDefaultAsync<User>(
                "sp_DeleteUser", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}