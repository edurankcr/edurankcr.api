namespace EduRankCR.Contracts.Account.Requests;

public sealed record UpdateProfileRequest(
    string? Name,
    string? LastName,
    string? UserName,
    DateTime? DateOfBirth,
    string? Biography);