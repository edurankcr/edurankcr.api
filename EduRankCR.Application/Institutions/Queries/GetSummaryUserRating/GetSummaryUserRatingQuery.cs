using EduRankCR.Application.Institutions.Common;

using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Institutions.Queries.GetSummaryUserRating;

public sealed record GetSummaryUserRatingQuery(Guid InstitutionId, Guid UserId)
    : IRequest<ErrorOr<InstitutionUserRatingResult>>;