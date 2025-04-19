namespace EduRankCR.Domain.Users;

public sealed class User
{
    public Guid UserId { get; private set; }
    public string Name { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string UserName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string? NewEmail { get; private set; }
    public bool EmailConfirmed { get; private set; }
    public string Password { get; private set; } = null!;
    public DateTime BirthDate { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private User() { }

    private User(Guid userId, string name, string lastName, string userName, string email, string? newEmail, string password, DateTime birthDate, DateTime createdAt, bool emailConfirmed)
    {
        UserId = userId;
        Name = name;
        LastName = lastName;
        UserName = userName;
        NewEmail = newEmail;
        Email = email;
        Password = password;
        BirthDate = birthDate;
        CreatedAt = createdAt;
        EmailConfirmed = emailConfirmed;
    }

    public static User Create(string name, string lastName, string userName, string email, string password, DateTime birthDate)
        => new(Guid.NewGuid(), name, lastName, userName, email, null, password, birthDate, DateTime.UtcNow, false);
}