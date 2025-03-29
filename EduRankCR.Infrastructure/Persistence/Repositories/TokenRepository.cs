using System.Data;
using Dapper;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.TokenAggregate.Entities;
using EduRankCR.Domain.TokenAggregate.ValueObjects;
using EduRankCR.Domain.UserAggregate.ValueObjects;

namespace EduRankCR.Infrastructure.Persistence.Repositories;

public class TokenRepository : ITokenRepository
{
    private readonly IDbContext _connectionFactory;

    public TokenRepository(IDbContext connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task Create(Token token)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@TokenId", token.Id.Value, DbType.Guid);
        parameters.Add("@UserId", token.UserId, DbType.Guid);
        parameters.Add("@Status", token.Status, DbType.String);
        parameters.Add("@CreatedAt", token.CreatedAt, DbType.DateTime);
        parameters.Add("@ExpiresAt", token.ExpiresAt, DbType.DateTime);

        await connection.QueryAsync("sp_Token__Create", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<Token?> Find(TokenId tokenId)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();

        parameters.Add("@TokenId", tokenId.Value, DbType.Guid);

        var tokenDto = await connection.QueryFirstOrDefaultAsync(
            "sp_Token__Find_Id",
            parameters,
            commandType: CommandType.StoredProcedure);

        if (tokenDto is null)
        {
            return null;
        }

        return Token.CreateFromPersistence(
            tokenDto.TokenId,
            tokenDto.UserId,
            tokenDto.Status,
            tokenDto.CreatedAt,
            tokenDto.ExpiresAt);
    }

    public async Task<Token?> FindByUserId(UserId userId)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId.Value, DbType.Guid);

        var tokenDto = await connection.QueryFirstOrDefaultAsync(
            "sp_Token__Find_UserId",
            parameters,
            commandType: CommandType.StoredProcedure);

        if (tokenDto is null)
        {
            return null;
        }

        return Token.CreateFromPersistence(
            tokenDto.TokenId,
            tokenDto.UserId,
            tokenDto.Status,
            tokenDto.CreatedAt,
            tokenDto.ExpiresAt);
    }

    public async Task VerifyEmail(TokenId tokenId)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@TokenId", tokenId.Value, DbType.Guid);

        await connection.QueryAsync("sp_Token__Verify_Email", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task VerifyChangeEmail(TokenId tokenId)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@TokenId", tokenId.Value, DbType.Guid);

        await connection.QueryAsync("sp_Token__Verify_Change_Email", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task VerifyPassword(TokenId tokenId, string password)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@TokenId", tokenId.Value, DbType.Guid);
        parameters.Add("@Password", password, DbType.String);

        await connection.QueryAsync("sp_Token__Verify_Password", parameters, commandType: CommandType.StoredProcedure);
    }
}