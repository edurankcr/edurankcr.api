using EduRankCR.Domain.TokenAggregate.Entities;
using EduRankCR.Domain.TokenAggregate.ValueObjects;

namespace EduRankCR.Application.Common.Interfaces.Persistence;

public interface ITokenRepository
{
    Task Create(Token token);
    Task<Token?> Find(TokenId tokenId);
    Task VerifyEmail(TokenId tokenId);
    Task VerifyChangeEmail(TokenId tokenId);
    Task VerifyPassword(TokenId tokenId, string password);
}