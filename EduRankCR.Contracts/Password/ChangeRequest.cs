namespace EduRankCR.Contracts.Password;

public record ChangeRequest(
    string CurrentPassword,
    string NewPassword);