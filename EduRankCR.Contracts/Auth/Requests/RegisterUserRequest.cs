namespace EduRankCR.Contracts.Auth.Requests;

public sealed record RegisterUserRequest(
    string Name,
    string LastName,
    string UserName,
    string Email,
    DateTime BirthDate,
    string Password);