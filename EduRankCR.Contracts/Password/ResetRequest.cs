namespace EduRankCR.Contracts.Password;

public record ResetRequest(
    string TokenId,
    string NewPassword);