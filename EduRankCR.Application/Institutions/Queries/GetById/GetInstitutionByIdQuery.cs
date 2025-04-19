using EduRankCR.Application.Institutions.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Institutions.Queries.GetById;

public sealed record GetInstitutionByIdQuery(Guid InstitutionId)
    : IRequest<ErrorOr<InstitutionResult>>;