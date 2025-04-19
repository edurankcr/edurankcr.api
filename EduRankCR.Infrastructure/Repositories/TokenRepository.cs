using System.Data;

using Dapper;

using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Users;

namespace EduRankCR.Infrastructure.Repositories;

public class TokenRepository : ITokenRepository
{
    private readonly IDbContext _dbContext;

    public TokenRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> GenerateEmailVerificationToken(User user)
    {
        using var connection = _dbContext.CreateConnection();

        var token = Guid.NewGuid().ToString();
        var expiration = DateTime.UtcNow.AddHours(1);

        const string procedure = "uprocedure_UserToken_Create";

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", user.UserId);
        parameters.Add("@Token", token);
        parameters.Add("@Type", TokenType.EmailVerification);
        parameters.Add("@ExpiresAt", expiration);

        await connection.ExecuteAsync(
            procedure,
            parameters,
            commandType: CommandType.StoredProcedure);

        return token;
    }

    public async Task<string?> GetValidEmailVerificationToken(Guid userId)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "uprocedure_UserToken_GetValid";

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId);
        parameters.Add("@Type", TokenType.EmailVerification);
        parameters.Add("@Now", DateTime.UtcNow);

        return await connection.QueryFirstOrDefaultAsync<string>(
            procedure,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task<string> GeneratePasswordResetToken(User user)
    {
        using var connection = _dbContext.CreateConnection();

        var token = Guid.NewGuid().ToString();
        var expiration = DateTime.UtcNow.AddHours(1);

        const string procedure = "uprocedure_UserToken_Create";

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", user.UserId);
        parameters.Add("@Token", token);
        parameters.Add("@Type", TokenType.PasswordReset);
        parameters.Add("@ExpiresAt", expiration);

        await connection.ExecuteAsync(
            procedure,
            parameters,
            commandType: CommandType.StoredProcedure);

        return token;
    }

    public async Task<string?> GetValidPasswordResetToken(Guid userId)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "uprocedure_UserToken_GetValid";

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId);
        parameters.Add("@Type", TokenType.PasswordReset);
        parameters.Add("@Now", DateTime.UtcNow);

        return await connection.QueryFirstOrDefaultAsync<string>(
            procedure,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task<Guid?> GetUserIdByVerificationToken(string token)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "uprocedure_UserToken_GetByToken";

        var parameters = new DynamicParameters();
        parameters.Add("@Token", token);
        parameters.Add("@Now", DateTime.UtcNow);

        return await connection.QueryFirstOrDefaultAsync<Guid?>(
            procedure,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task DeleteAllByUserId(Guid userId, TokenType tokenType)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "uprocedure_UserToken_DeleteAllByUserId";

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId);
        parameters.Add("@Type", tokenType);

        await connection.ExecuteAsync(
            procedure,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task MarkAsUsed(string token)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "uprocedure_UserToken_MarkAsUsed";

        await connection.ExecuteAsync(
            procedure,
            new { Token = token },
            commandType: CommandType.StoredProcedure);
    }
}