using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Common.Models;
using EduRankCR.Domain.TokenAggregate.ValueObjects;

namespace EduRankCR.Domain.TokenAggregate.Entities;

public sealed class Token : Entity<TokenId>
{
    public Guid UserId { get; }
    public TokenStatus Status { get; }
    public DateTime CreatedAt { get; }
    public DateTime ExpiresAt { get; }

    private Token(
        TokenId tokenId,
        Guid userId,
        TokenStatus status,
        DateTime createdAt,
        DateTime expiresAt)
        : base(tokenId)
    {
        UserId = userId;
        Status = status;
        CreatedAt = createdAt;
        ExpiresAt = expiresAt;
    }

    public static Token Create(
        Guid userId,
        DateTime expiresAt)
    {
        var emailVerificationToken = new Token(
            TokenId.CreateUnique(),
            userId,
            TokenStatus.Pending,
            DateTime.Now,
            expiresAt);

        return emailVerificationToken;
    }

    public static Token CreateFromPersistence(
        Guid tokenId,
        Guid userId,
        byte status,
        DateTime createdAt,
        DateTime expiresAt)
    {
        var emailVerificationToken = new Token(
            new TokenId(tokenId),
            userId,
            (TokenStatus)status,
            createdAt,
            expiresAt);

        return emailVerificationToken;
    }
}