using System.Data;
using Dapper;
using EduRankCR.Application.DTOs;
using EduRankCR.Application.Interfaces;
using EduRankCR.Domain.Entities;
using EduRankCR.Domain.Exceptions;
using EduRankCR.Infrastructure.Data;
using Microsoft.Data.SqlClient;

namespace EduRankCR.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UserRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        
        public async Task<User> CreateUserAsync(RequestUserCreateDto requestUserCreateDto)
        {
            using IDbConnection connection = _connectionFactory.CreateConnection();
            var parameters = new
            {
                requestUserCreateDto.Name,
                requestUserCreateDto.LastName,
                requestUserCreateDto.Username,
                requestUserCreateDto.Email,
                requestUserCreateDto.EmailConfirmed,
                requestUserCreateDto.Role,
                requestUserCreateDto.Birthdate,
                requestUserCreateDto.Password,
                requestUserCreateDto.AvatarUrl,
                requestUserCreateDto.Biography
            };

            try
            {
                var user = await connection.QueryFirstOrDefaultAsync<User>(
                    "sp_CreateUser", parameters, commandType: CommandType.StoredProcedure);

                if (user == null)
                {
                    throw new NotFoundException("USER_NOT_FOUND");
                }

                return user;
            }
            catch (SqlException ex) when (ex.Message.Contains("USER_NOT_FOUND"))
            {
                throw new NotFoundException("User creation failed: User not found in the database.");
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while creating the user.", ex);
            }
        }
        
        public async Task<List<User>> GetAllUsersAsync()
        {
            using IDbConnection connection = _connectionFactory.CreateConnection();

            try
            {
                var users = await connection.QueryAsync<User>("sp_GetAllUsers", commandType: CommandType.StoredProcedure);
                
                if (users == null)
                {
                    throw new NotFoundException("USERS_NOT_FOUND");
                }
                
                return users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while fetching the users.", ex);
            }
        }
        
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            using IDbConnection connection = _connectionFactory.CreateConnection();
            var parameters = new { UserId = id };
            
            try
            {
                var user = await connection.QueryFirstOrDefaultAsync<User>(
                    "sp_GetUserById", parameters, commandType: CommandType.StoredProcedure);
                
                return user!;
            } catch (SqlException ex) when (ex.Message.Contains("USER_NOT_FOUND"))
            {
                throw new NotFoundException("User not found in the database.");
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while fetching the user.", ex);
            }
        }
        
        public async Task<User> UpdateUserAsync(Guid id, RequestUserUpdateDto requestUserUpdateDto)
        {
            using IDbConnection connection = _connectionFactory.CreateConnection();
            var parameters = new
            {
                UserId = id,
                requestUserUpdateDto.Name,
                requestUserUpdateDto.LastName,
                requestUserUpdateDto.Username,
                requestUserUpdateDto.Email,
                requestUserUpdateDto.EmailConfirmed,
                requestUserUpdateDto.Birthdate,
                requestUserUpdateDto.Role,
                requestUserUpdateDto.Status,
                requestUserUpdateDto.AvatarUrl,
                requestUserUpdateDto.Biography
            };

            try
            {
                var user = await connection.QueryFirstOrDefaultAsync<User>(
                    "sp_UpdateUser", parameters, commandType: CommandType.StoredProcedure);

                return user!;
            } catch (SqlException ex) when (ex.Message.Contains("USER_NOT_FOUND"))
            {
                throw new NotFoundException("User not found in the database.");
            } catch (SqlException ex) when (ex.Message.Contains("EMPTY_UPDATE"))
            {
                throw new Exception("No changes were made to the user.");
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while updating the user.", ex);
            }
        }
        
        public async Task<User> DeleteUserAsync(Guid id)
        {
            using IDbConnection connection = _connectionFactory.CreateConnection();
            var parameters = new { UserId = id };

            try
            {
                var user = await connection.QueryFirstOrDefaultAsync<User>(
                    "sp_DeleteUser", parameters, commandType: CommandType.StoredProcedure);
                
                return user!;
            } catch (SqlException ex) when (ex.Message.Contains("USER_NOT_FOUND"))
            {
                throw new NotFoundException("User not found in the database.");
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while deleting the user.", ex);
            }
        }
    }
}