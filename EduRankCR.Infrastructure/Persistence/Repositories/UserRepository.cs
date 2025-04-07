using System.Data;
using Dapper;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.UserAggregate.Entities;
using EduRankCR.Domain.UserAggregate.ValueObjects;

namespace EduRankCR.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbContext _connectionFactory;
    private readonly IDomainEventDispatcher _eventDispatcher;

    public UserRepository(IDbContext connectionFactory, IDomainEventDispatcher eventDispatcher)
    {
        _connectionFactory = connectionFactory;
        _eventDispatcher = eventDispatcher;
    }

    public async Task Create(User user)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", user.Id.Value);
        parameters.Add("@Name", user.Name);
        parameters.Add("@LastName", user.LastName);
        parameters.Add("@UserName", user.UserName);
        parameters.Add("@Email", user.Email);
        parameters.Add("@Password", user.Password);
        parameters.Add("@BirthDate", user.BirthDate);

        await connection.QueryAsync("sp_User__Create", parameters, commandType: CommandType.StoredProcedure);

        await _eventDispatcher.DispatchEventsAsync(user);
    }

    public async Task<User?> Find(string identifier)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();

        parameters.Add("@Identifier", identifier, DbType.String);

        var userDto = await connection.QueryFirstOrDefaultAsync(
            "sp_User__Find_Identifier",
            parameters,
            commandType: CommandType.StoredProcedure);

        if (userDto is null)
        {
            return null;
        }

        return User.CreateFromPersistence(
            userDto.UserId,
            userDto.Name,
            userDto.LastName,
            userDto.UserName,
            userDto.Email,
            userDto.EmailConfirmed,
            userDto.NewEmail,
            userDto.BirthDate,
            userDto.Password,
            userDto.Role,
            userDto.Status,
            userDto.AvatarUrl,
            userDto.Biography,
            userDto.CreatedAt,
            userDto.UpdatedAt);
    }

    public async Task<User?> FindById(UserId userId)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId.Value, DbType.Guid);

        var userDto = await connection.QueryFirstOrDefaultAsync(
            "sp_User__Find_Id",
            parameters,
            commandType: CommandType.StoredProcedure);

        if (userDto is null)
        {
            return null;
        }

        return User.CreateFromPersistence(
            userDto.UserId,
            userDto.Name,
            userDto.LastName,
            userDto.UserName,
            userDto.Email,
            userDto.EmailConfirmed,
            userDto.NewEmail,
            userDto.BirthDate,
            userDto.Password,
            userDto.Role,
            userDto.Status,
            userDto.AvatarUrl,
            userDto.Biography,
            userDto.CreatedAt,
            userDto.UpdatedAt);
    }

    public async Task UpdatePassword(UserId userId, string password)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId.Value);
        parameters.Add("@Password", password);

        await connection.QueryAsync("sp_User__Update_Password", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateProfile(
        UserId userId,
        string? name,
        string? lastName,
        string? userName,
        DateTime? birthDate,
        string? biography)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId.Value);
        parameters.Add("@Name", name);
        parameters.Add("@LastName", lastName);
        parameters.Add("@UserName", userName);
        parameters.Add("@BirthDate", birthDate);
        parameters.Add("@Biography", biography);

        await connection.QueryAsync("sp_User__Update_Profile", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateEmail(UserId userId, string newEmail, bool isNewEmail)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId.Value);
        parameters.Add("@Email", newEmail);
        parameters.Add("@IsNewEmail", isNewEmail);

        await connection.QueryAsync("sp_User__Update_Email", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateAvatar(UserId userId, string avatarUrl)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId.Value);
        parameters.Add("@AvatarUrl", avatarUrl);

        await connection.QueryAsync("sp_User__Update_Profile", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task DeleteChangeEmail(UserId userId)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId.Value);

        await connection.QueryAsync("sp_User__Delete_Change_Email", parameters, commandType: CommandType.StoredProcedure);
    }
}