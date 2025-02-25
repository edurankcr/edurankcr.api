using System.Data;
using Dapper;
using EduRankCR.Application.Common.Interfaces.Persistence;
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
        parameters.Add("@UserId", user.Id.Value, DbType.Guid);
        parameters.Add("@Name", user.Name, DbType.String);
        parameters.Add("@LastName", user.LastName, DbType.String);
        parameters.Add("@UserName", user.UserName, DbType.String);
        parameters.Add("@Email", user.Email, DbType.String);
        parameters.Add("@Password", user.Password, DbType.String);
        parameters.Add("@BirthDate", user.BirthDate, DbType.DateTime);

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
        parameters.Add("@UserId", userId.Value, DbType.Guid);
        parameters.Add("@Password", password, DbType.String);

        await connection.QueryAsync("sp_User__Update_Password", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateProfile(
        UserId userId,
        string? name,
        string? lastName,
        string? userName,
        DateTime? birthDate,
        string? avatarUrl,
        string? biography)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId.Value, DbType.Guid);
        parameters.Add("@Name", name, DbType.String);
        parameters.Add("@LastName", lastName, DbType.String);
        parameters.Add("@UserName", userName, DbType.String);
        parameters.Add("@BirthDate", birthDate, DbType.DateTime);
        parameters.Add("@AvatarUrl", avatarUrl, DbType.String);
        parameters.Add("@Biography", biography, DbType.String);

        await connection.QueryAsync("sp_User__Update_Profile", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateEmail(UserId userId, string newEmail, bool isNewEmail)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId.Value, DbType.Guid);
        parameters.Add("@Email", newEmail, DbType.String);
        parameters.Add("@IsNewEmail", isNewEmail, DbType.Boolean);

        await connection.QueryAsync("sp_User__Update_Email", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateAvatar(UserId userId, string avatarUrl)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId.Value, DbType.Guid);
        parameters.Add("@AvatarUrl", avatarUrl, DbType.String);

        await connection.QueryAsync("sp_User__Update_Profile", parameters, commandType: CommandType.StoredProcedure);
    }
}