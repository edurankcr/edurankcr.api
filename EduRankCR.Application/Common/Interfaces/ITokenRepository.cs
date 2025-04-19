using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Users;

namespace EduRankCR.Application.Common.Interfaces;

public interface ITokenRepository
{
    Task<string> GenerateEmailVerificationToken(User user);
    Task<string?> GetValidEmailVerificationToken(Guid userId);
    Task<string> GeneratePasswordResetToken(User user);
    Task<string?> GetValidPasswordResetToken(Guid userId);
    Task<Guid?> GetUserIdByVerificationToken(string token);
    Task DeleteAllByUserId(Guid userId, TokenType tokenType);
    Task MarkAsUsed(string token);
}