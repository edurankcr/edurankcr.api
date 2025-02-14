using API.EduRankCR.Data;
using API.EduRankCR.Shared.DTOs;
using API.EduRankCR.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace API.EduRankCR.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly APIEduRankCRContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(APIEduRankCRContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ApiResponse<NewUserResponseDTO>> CreateUserAsync(NewUserRequestDTO userDTO)
        {
            try
            {
                // Hash the password before passing it to the stored procedure.
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);

                // Execute stored procedure to insert the user.
                var result = await _context
                    .Set<NewUserResponseDTO>()
                    .FromSqlRaw(
                        "EXEC SP_InsertUser @p0, @p1, @p2, @p3, @p4, @p5",
                        userDTO.Name,
                        userDTO.LastName,
                        userDTO.Username,
                        userDTO.Email,
                        userDTO.BirthDate,
                        hashedPassword
                    )
                    .ToListAsync();

                if (result == null || !result.Any())
                {
                    _logger.LogWarning("User creation stored procedure returned no result for username: {Username}", userDTO.Username);
                    return ApiResponse<NewUserResponseDTO>.ErrorResponse("User creation failed");
                }

                var createdUser = result.First();
                return ApiResponse<NewUserResponseDTO>.SuccessResponse(createdUser, "User created successfully");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Database error occurred while creating user with username: {Username}", userDTO.Username);
                return ApiResponse<NewUserResponseDTO>.ErrorResponse(
                    "Database error",
                    new List<string> { ex.InnerException?.Message ?? ex.Message }
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while creating user with username: {Username}", userDTO.Username);
                return ApiResponse<NewUserResponseDTO>.ErrorResponse(
                    "Internal Server Error",
                    new List<string> { ex.Message }
                );
            }
        }

        public async Task<ApiResponse<NewUserResponseDTO>> GetUserByIdAsync(Guid id)
        {
            try
            {
                var user = await _context.User
                    .Where(u => u.Id == id)
                    .Select(u => new NewUserResponseDTO
                    {
                        Id = u.Id
                    })
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    _logger.LogInformation("User not found with ID: {UserId}", id);
                    return ApiResponse<NewUserResponseDTO>.ErrorResponse("User not found");
                }

                return ApiResponse<NewUserResponseDTO>.SuccessResponse(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occurred while fetching user with ID: {UserId}", id);
                return ApiResponse<NewUserResponseDTO>.ErrorResponse(
                    "Internal Server Error",
                    new List<string> { ex.Message }
                );
            }
        }
    }
}
