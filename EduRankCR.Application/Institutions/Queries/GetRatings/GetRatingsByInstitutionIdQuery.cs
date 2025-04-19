using EduRankCR.Application.Institutions.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Institutions.Queries.GetRatings;

public sealed record GetRatingsByInstitutionIdQuery(Guid InstitutionId)
    : IRequest<ErrorOr<List<InstitutionRatingResult>>>;