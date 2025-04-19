namespace EduRankCR.Contracts.Auth.Requests;

public sealed record ResetPasswordRequest(string Token, string NewPassword);