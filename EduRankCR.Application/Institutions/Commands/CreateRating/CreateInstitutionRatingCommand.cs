using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Institutions.Commands.CreateRating;

public sealed record CreateInstitutionRatingCommand(
    Guid InstitutionId,
    Guid UserId,
    int Location,
    int Happiness,
    int Safety,
    int Reputation,
    int Opportunities,
    int Internet,
    int Food,
    int Social,
    int Facilities,
    int Clubs,
    string Testimony) : IRequest<ErrorOr<Unit>>;