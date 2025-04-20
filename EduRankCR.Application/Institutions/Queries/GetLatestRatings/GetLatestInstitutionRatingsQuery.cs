using EduRankCR.Application.Institutions.Common;

using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Institutions.Queries.GetLatestRatings;

public sealed record GetLatestInstitutionRatingsQuery()
    : IRequest<ErrorOr<GetLatestInstitutionRatingsResult>>;