namespace EduRankCR.Contracts.Auth.Requests;

public record LoginRequest(
    string Identifier,
    string Password);