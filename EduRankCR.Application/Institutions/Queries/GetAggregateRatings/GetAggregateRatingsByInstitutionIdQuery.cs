using EduRankCR.Application.Institutions.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Institutions.Queries.GetAggregateRatings;

public sealed record GetAggregateRatingsByInstitutionIdQuery(Guid InstitutionId)
    : IRequest<ErrorOr<InstitutionRatingAggregateResult>>;