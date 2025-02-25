namespace EduRankCR.Contracts.Register;

public record RegisterRequest(
    string Name,
    string LastName,
    string UserName,
    string Email,
    DateTime BirthDate,
    string Password);