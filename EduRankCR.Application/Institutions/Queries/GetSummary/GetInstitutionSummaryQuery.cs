using EduRankCR.Application.Institutions.Common;

using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Institutions.Queries.GetSummary;

public record GetInstitutionSummaryQuery(Guid InstitutionId)
    : IRequest<ErrorOr<InstitutionSummaryResult>>;