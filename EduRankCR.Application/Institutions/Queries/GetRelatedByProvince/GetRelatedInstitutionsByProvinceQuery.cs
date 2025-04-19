using EduRankCR.Application.Institutions.Common;

using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Institutions.Queries.GetRelatedByProvince;

public sealed record GetRelatedInstitutionsByProvinceQuery(Guid InstitutionId)
    : IRequest<ErrorOr<List<InstitutionRelatedResult>>>;