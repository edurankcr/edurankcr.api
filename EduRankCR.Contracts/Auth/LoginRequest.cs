namespace EduRankCR.Contracts.Auth;

public record LoginRequest(
    string Identifier,
    string Password);