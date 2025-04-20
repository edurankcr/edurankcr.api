namespace EduRankCR.Application.Institutions.Common;

public record InstitutionSummaryResult(
    InstitutionResult Institution,
    InstitutionRatingAggregateResult AggregateRatings,
    List<InstitutionRelatedResult>? RelatedInstitutions);