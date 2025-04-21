using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Institutions.Commands.UpdateRating;

public sealed record UpdateInstitutionRatingCommand(
    Guid InstitutionId,
    Guid UserId,
    int? Location,
    int? Happiness,
    int? Safety,
    int? Reputation,
    int? Opportunities,
    int? Internet,
    int? Food,
    int? Social,
    int? Facilities,
    int? Clubs,
    string? Testimony) : IRequest<ErrorOr<Unit>>;