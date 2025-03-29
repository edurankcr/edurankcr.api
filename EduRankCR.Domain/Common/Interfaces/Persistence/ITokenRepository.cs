using EduRankCR.Domain.TokenAggregate.Entities;
using EduRankCR.Domain.TokenAggregate.ValueObjects;
using EduRankCR.Domain.UserAggregate.ValueObjects;

namespace EduRankCR.Domain.Common.Interfaces.Persistence;

public interface ITokenRepository
{
    Task Create(Token token);
    Task<Token?> Find(TokenId tokenId);
    Task<Token?> FindByUserId(UserId userId);
    Task VerifyEmail(TokenId tokenId);
    Task VerifyChangeEmail(TokenId tokenId);
    Task VerifyPassword(TokenId tokenId, string password);
}