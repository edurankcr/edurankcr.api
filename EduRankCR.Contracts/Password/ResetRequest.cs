namespace EduRankCR.Contracts.Password;

public record ResetRequest(
    Guid Token,
    string NewPassword);