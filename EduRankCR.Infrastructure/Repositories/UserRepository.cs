using System.Data;

using Dapper;

using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Domain.Users;
using EduRankCR.Domain.Users.Projections;

namespace EduRankCR.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbContext _dbContext;

    public UserRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string?> GetExistingIdentifier(string email, string userName)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_User_IdentifierExists";

        var parameters = new DynamicParameters();
        parameters.Add("@Email", email);
        parameters.Add("@UserName", userName);
        parameters.Add("@ExistingIdentifier", dbType: DbType.String, direction: ParameterDirection.Output, size: 10);

        await connection.ExecuteAsync(
            procedure,
            parameters,
            commandType: CommandType.StoredProcedure);

        return parameters.Get<string>("@ExistingIdentifier");
    }

    public async Task<UserLoginProjection?> GetByIdentifier(string identifier)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_User_GetByIdentifier";

        return await connection.QueryFirstOrDefaultAsync<UserLoginProjection>(
            procedure,
            new { Identifier = identifier },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<User?> GetByEmail(string email)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_User_GetByEmail";

        return await connection.QueryFirstOrDefaultAsync<User>(
            procedure,
            new { Email = email },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<User?> GetById(Guid userId)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_User_GetById";

        return await connection.QueryFirstOrDefaultAsync<User>(
            procedure,
            new { UserId = userId },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<UserProjection?> GetProfileById(Guid userId)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_User_GetProfileById";

        return await connection.QueryFirstOrDefaultAsync<UserProjection>(
            procedure,
            new { UserId = userId },
            commandType: CommandType.StoredProcedure);
    }

    public async Task Create(User user)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_User_Create";

        var parameters = new
        {
            user.Name,
            user.LastName,
            user.UserName,
            user.Email,
            user.Password,
            user.BirthDate,
        };

        await connection.ExecuteAsync(
            procedure,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task ConfirmEmail(Guid userId)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_User_ConfirmEmail";

        await connection.ExecuteAsync(
            procedure,
            new { UserId = userId },
            commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateEmail(Guid userId, string newEmail)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_User_UpdateEmail";

        var parameters = new
        {
            UserId = userId,
            NewEmail = newEmail,
        };

        await connection.ExecuteAsync(
            procedure,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateNewEmail(Guid userId, string? newEmail)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_User_UpdateNewEmail";

        var parameters = new
        {
            UserId = userId,
            NewEmail = newEmail,
        };

        await connection.ExecuteAsync(
            procedure,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task UpdatePassword(Guid userId, string newPassword)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_User_UpdatePassword";

        var parameters = new
        {
            UserId = userId,
            NewPassword = newPassword,
        };

        await connection.ExecuteAsync(
            procedure,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateProfile(
        Guid userId,
        string? name,
        string? lastName,
        string? userName,
        DateTime? dateOfBirth,
        string? biography)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_User_UpdateProfile";

        var parameters = new
        {
            UserId = userId,
            Name = name,
            LastName = lastName,
            UserName = userName,
            Birthdate = dateOfBirth,
            Biography = biography,
        };

        await connection.ExecuteAsync(
            procedure,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateAvatar(Guid userId, string? avatarUrl)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_User_UpdateAvatarUrl";

        var parameters = new
        {
            UserId = userId,
            AvatarUrl = avatarUrl,
        };

        await connection.ExecuteAsync(
            procedure,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> IsUserNameTaken(string userName)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_User_IsUserNameTaken";

        return await connection.ExecuteScalarAsync<bool>(
            procedure,
            new { UserName = userName },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> IsEmailTaken(string email)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_User_IsEmailTaken";

        return await connection.ExecuteScalarAsync<bool>(
            procedure,
            new { Email = email },
            commandType: CommandType.StoredProcedure);
    }
}