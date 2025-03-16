namespace EduRankCR.Contracts.Password;

public record ResetRequest(
    string Token,
    string NewPassword);