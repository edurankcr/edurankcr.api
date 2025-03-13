using EduRankCR.Domain.UserAggregate.Entities;
using EduRankCR.Domain.UserAggregate.ValueObjects;

namespace EduRankCR.Domain.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task Create(User user);
    Task<User?> Find(string identifier);
    Task<User?> FindById(UserId userId);
    Task UpdatePassword(UserId userId, string password);
    Task UpdateProfile(
        UserId userId,
        string? name,
        string? lastName,
        string? userName,
        DateTime? birthDate,
        string? avatarUrl,
        string? biography);
    Task UpdateEmail(UserId userId, string newEmail, bool isNewEmail);
    Task UpdateAvatar(UserId userId, string avatarUrl);
}