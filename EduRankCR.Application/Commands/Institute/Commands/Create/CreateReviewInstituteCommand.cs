using EduRankCR.Application.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Institute.Commands.Create;

public record CreateReviewInstituteCommand(
    decimal Reputation,
    decimal Opportunities,
    decimal Happiness,
    decimal Location,
    decimal Facilities,
    decimal Social,
    decimal Clubs,
    decimal Internet,
    decimal Security,
    decimal Food,
    string ExperienceText,
    string UserId,
    string InstituteId) : IRequest<ErrorOr<BoolResult>>;