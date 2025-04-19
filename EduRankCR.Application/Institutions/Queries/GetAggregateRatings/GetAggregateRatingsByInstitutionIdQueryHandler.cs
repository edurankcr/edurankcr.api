using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Application.Institutions.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Institutions.Queries.GetAggregateRatings;

internal sealed class GetAggregateRatingsByInstitutionIdQueryHandler : IRequestHandler<GetAggregateRatingsByInstitutionIdQuery, ErrorOr<InstitutionRatingAggregateResult>>
{
    private readonly IInstitutionRatingAggregateRepository _repository;

    public GetAggregateRatingsByInstitutionIdQueryHandler(IInstitutionRatingAggregateRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<InstitutionRatingAggregateResult>> Handle(GetAggregateRatingsByInstitutionIdQuery request, CancellationToken cancellationToken)
    {
        var aggregate = await _repository.GetByInstitutionId(request.InstitutionId);

        if (aggregate is null)
        {
            return Errors.Institution.NullRatingAggregate;
        }

        return new InstitutionRatingAggregateResult(
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
    }
}