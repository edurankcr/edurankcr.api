using API.EduRankCR.Data;
using API.EduRankCR.Shared.DTOs;
using Microsoft.EntityFrameworkCore;
using API.EduRankCR.Shared.Responses;

namespace API.EduRankCR.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly APIEduRankCRContext _context;

        public UserRepository(APIEduRankCRContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<NewUserResponseDTO>> CreateUserAsync(
            NewUserRequestDTO userDTO
        )
        {
            try
            {
                var result = await _context
                    .Set<NewUserResponseDTO>()
                    .FromSqlRaw(
                        "EXEC SP_InsertUser @p0, @p1, @p2, @p3, @p4, @p5",
                        userDTO.Name,
                        userDTO.LastName,
                        userDTO.Username,
                        userDTO.Email,
                        userDTO.BirthDate,
                        BCrypt.Net.BCrypt.HashPassword(userDTO.Password)
                    )
                    .ToListAsync();

                if (result == null || result.Count == 0)
                {
                    return ApiResponse<NewUserResponseDTO>.ErrorResponse("User creation failed");
                }

                return ApiResponse<NewUserResponseDTO>.SuccessResponse(
                    result.First(),
                    "User created successfully"
                );
            }
            catch (DbUpdateException ex)
            {
                return ApiResponse<NewUserResponseDTO>.ErrorResponse(
                    "Database error",
                    new List<string> { ex.InnerException?.Message ?? ex.Message }
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<NewUserResponseDTO>.ErrorResponse(
                    "Internal Server Error",
                    new List<string> { ex.Message }
                );
            }
        }

        public async Task<ApiResponse<NewUserResponseDTO?>> GetUserByIdAsync(Guid id)
        {
            var user = await _context.Users
                .Where(u => u.Id == id)
                .Select(u => new NewUserResponseDTO { Id = u.Id, })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return ApiResponse<NewUserResponseDTO?>.ErrorResponse("User not found");
            }

            return ApiResponse<NewUserResponseDTO?>.SuccessResponse(user);
        }
    }
}
