namespace EduRankCR.Contracts.Account;

public sealed record UpdateProfileRequest(
    string? Name,
    string? LastName,
    string? UserName,
    DateTime? BirthDate,
    string? Biography);