namespace EduRankCR.Contracts.Teachers.Requests;

public sealed record CreateTeacherRequest(
    string Name,
    string LastName,
    string? Biography);