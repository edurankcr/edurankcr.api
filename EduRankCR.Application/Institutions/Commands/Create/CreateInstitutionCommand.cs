using EduRankCR.Application.Institutions.Common;
using EduRankCR.Domain.Common.Enums;

using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Institutions.Commands.Create;

public sealed record CreateInstitutionCommand(
    Guid UserId,
    string Name,
    string? Description,
    Province Province,
    InstitutionType Type,
    string? WebsiteUrl) : IRequest<ErrorOr<CreateInstitutionResult>>;