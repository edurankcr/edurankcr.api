using EduRankCR.Domain.Common.Models;
using EduRankCR.Domain.UserAggregate.Enums;
using EduRankCR.Domain.UserAggregate.Events;
using EduRankCR.Domain.UserAggregate.ValueObjects;

namespace EduRankCR.Domain.UserAggregate.Entities;

public sealed class User : Entity<UserId>
{
    public string Name { get; }
    public string LastName { get; }
    public string UserName { get; }
    public string Email { get; }
    public bool EmailConfirmed { get; }
    public string? NewEmail { get; }
    public DateTime BirthDate { get; }
    public string Password { get; }
    public UserRole Role { get; }
    public UserStatus Status { get; }
    public string? AvatarUrl { get; }
    public string? Biography { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    private User(
        UserId userId,
        string name,
        string lastName,
        string userName,
        string email,
        bool emailConfirmed,
        string? newEmail,
        DateTime birthDate,
        string password,
        UserRole role,
        UserStatus status,
        string? avatarUrl,
        string? biography,
        DateTime createdAt,
        DateTime updatedAt)
        : base(userId)
    {
        Name = name;
        LastName = lastName;
        UserName = userName;
        Email = email;
        EmailConfirmed = emailConfirmed;
        NewEmail = newEmail;
        BirthDate = birthDate;
        Password = password;
        Role = role;
        Status = status;
        AvatarUrl = avatarUrl;
        Biography = biography;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static User Create(
        string name,
        string lastName,
        string userName,
        string email,
        DateTime birthDate,
        string password)
    {
        var user = new User(
            UserId.CreateUnique(),
            name,
            lastName,
            userName,
            email,
            false,
            null,
            birthDate,
            password,
            UserRole.User,
            UserStatus.Active,
            null,
            null,
            DateTime.Now,
            DateTime.Now);

        user.AddDomainEvent(new UserCreated(user));

        return user;
    }

    public static User CreateFromPersistence(
        Guid userId,
        string name,
        string lastName,
        string userName,
        string email,
        bool emailConfirmed,
        string? newEmail,
        DateTime birthDate,
        string password,
        byte role,
        byte status,
        string? avatarUrl,
        string? biography,
        DateTime createdAt,
        DateTime updatedAt)
    {
        var user = new User(
            new UserId(userId),
            name,
            lastName,
            userName,
            email,
            emailConfirmed,
            newEmail,
            birthDate,
            password,
            (UserRole)role,
            (UserStatus)status,
            avatarUrl,
            biography,
            createdAt,
            updatedAt);

        return user;
    }
}