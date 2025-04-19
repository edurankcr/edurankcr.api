using EduRankCR.Application.Institutions.Common;

using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Institutions.Queries.GetInstitutionById;

public sealed record GetInstitutionByIdQuery(Guid InstitutionId) : IRequest<ErrorOr<InstitutionBasicInfoResult>>;