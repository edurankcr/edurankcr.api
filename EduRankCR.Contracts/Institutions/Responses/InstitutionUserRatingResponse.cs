namespace EduRankCR.Contracts.Institutions.Responses;

public sealed record InstitutionUserRatingResponse(
    bool HasRating,
    InstitutionRatingInstitutionResponse? Rating,
    InstitutionResponse Institution);