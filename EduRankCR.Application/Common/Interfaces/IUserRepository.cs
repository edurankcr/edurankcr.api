using EduRankCR.Domain.Users;
using EduRankCR.Domain.Users.Projections;

namespace EduRankCR.Application.Common.Interfaces;

public interface IUserRepository
{
    Task<string?> GetExistingIdentifier(string email, string userName);
    Task<UserLoginProjection?> GetByIdentifier(string identifier);
    Task<User?> GetByEmail(string email);
    Task<User?> GetById(Guid userId);
    Task<UserProjection?> GetProfileById(Guid userId);
    Task Create(User user);
    Task ConfirmEmail(Guid userId);
    Task UpdateEmail(Guid userId, string newEmail);
    Task UpdateNewEmail(Guid userId, string? newEmail);
    Task UpdatePassword(Guid userId, string newPassword);
    Task UpdateProfile(Guid userId, string? name, string? lastName, string? userName, DateTime? dateOfBirth, string? biography);
    Task UpdateAvatar(Guid userId, string? avatarUrl);
    Task<bool> IsUserNameTaken(string userName);
    Task<bool> IsEmailTaken(string email);
}