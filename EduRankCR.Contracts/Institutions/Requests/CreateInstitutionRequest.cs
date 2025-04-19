namespace EduRankCR.Contracts.Institutions.Requests;

public sealed record CreateInstitutionRequest(
    string Name,
    string? Description,
    byte Province,
    byte Type,
    string? WebsiteUrl);