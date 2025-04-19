namespace EduRankCR.Contracts.Account.Requests;

public sealed record ChangePasswordRequest(
    string CurrentPassword,
    string NewPassword);