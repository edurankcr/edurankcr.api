namespace EduRankCR.Contracts.Account;

public record ChangePasswordRequest(
    string CurrentPassword,
    string NewPassword);