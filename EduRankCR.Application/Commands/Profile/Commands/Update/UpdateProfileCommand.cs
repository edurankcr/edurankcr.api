using EduRankCR.Application.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Profile.Commands.Update;

public record UpdateProfileCommand(
    string? Name,
    string? LastName,
    string? UserName,
    DateTime? BirthDate,
    string? AvatarUrl,
    string? Biography,
    string UserId) : IRequest<ErrorOr<BoolResult>>;