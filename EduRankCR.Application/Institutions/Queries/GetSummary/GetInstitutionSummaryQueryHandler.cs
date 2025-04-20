using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Application.Institutions.Common;

using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Institutions.Queries.GetSummary;

public class GetInstitutionSummaryQueryHandler
    : IRequestHandler<GetInstitutionSummaryQuery, ErrorOr<InstitutionSummaryResult>>
{
    private readonly IInstitutionRepository _institutionRepository;
    private readonly IInstitutionRatingAggregateRepository _aggregationRepository;

    public GetInstitutionSummaryQueryHandler(
        IInstitutionRepository institutionRepository,
        IInstitutionRatingAggregateRepository ratingRepository)
    {
        _institutionRepository = institutionRepository;
        _aggregationRepository = ratingRepository;
    }

    public async Task<ErrorOr<InstitutionSummaryResult>> Handle(GetInstitutionSummaryQuery request, CancellationToken cancellationToken)
    {
        var institutionTask = _institutionRepository.GetById(request.InstitutionId);
        var aggregateTask = _aggregationRepository.GetByInstitutionId(request.InstitutionId);
        var relatedTask = _institutionRepository.GetRelatedByProvince(request.InstitutionId);

        await Task.WhenAll(institutionTask, aggregateTask, relatedTask);

        var institution = await institutionTask;
        if (institution is null)
        {
            return Errors.Institution.NotFound;
        }

        var aggregate = await aggregateTask;
        if (aggregate is null)
        {
            return Errors.Institution.NullRatingAggregate;
        }

        var related = await relatedTask;

        var institutionResult = new InstitutionResult(
            institution.InstitutionId,
            institution.Name,
            institution.Description,
            institution.Province,
            (byte)institution.Type,
            institution.WebsiteUrl,
            institution.AiReviewSummary,
            institution.CreatedAt,
            institution.UpdatedAt,
            (byte)institution.Status);

        var ratingResult = new InstitutionRatingAggregateResult(
            aggregate.Location,
            aggregate.Happiness,
            aggregate.Safety,
            aggregate.Reputation,
            aggregate.Opportunities,
            aggregate.Internet,
            aggregate.Food,
            aggregate.Social,
            aggregate.Facilities,
            aggregate.Clubs,
            aggregate.OverallAverage,
            aggregate.ReviewCount);

        var relatedInstitutions = related
            .Select(x => new InstitutionRelatedResult(
                x.InstitutionId,
                x.Name,
                x.Description,
                x.Province,
                x.Type,
                x.WebsiteUrl,
                x.OverallAverage,
                x.ReviewCount))
            .ToList();

        return new InstitutionSummaryResult(institutionResult, ratingResult, relatedInstitutions);
    }
}