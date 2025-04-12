namespace EduRankCR.Contracts.Reviews;

public record ReviewInstituteDto(
    Guid InstituteId,
    string InstituteName,
    Guid ReviewId,
    decimal Reputation,
    decimal Opportunities,
    decimal Happiness,
    decimal Location,
    decimal Facilities,
    decimal Social,
    decimal Clubs,
    decimal Internet,
    decimal Security,
    decimal Food,
    string ExperienceText,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string UserFirstName,
    string UserLastName,
    string UserName,
    string? AvatarUrl);