namespace EduRankCR.Application.Institutions.Common;

public sealed record InstitutionUserRatingResult(
    bool HasRating,
    InstitutionRatingInstitutionResult? Rating,
    InstitutionResult Institution);