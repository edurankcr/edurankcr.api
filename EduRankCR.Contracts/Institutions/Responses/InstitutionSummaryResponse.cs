namespace EduRankCR.Contracts.Institutions.Responses;

public record InstitutionSummaryResponse
{
    public InstitutionResponse Institution { get; init; } = null!;
    public InstitutionRatingAggregateResponse AggregateRatings { get; init; } = null!;
    public List<InstitutionRelatedResponse> RelatedInstitutions { get; init; } = [];
}