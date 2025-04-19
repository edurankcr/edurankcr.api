using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Account.Commands.UpdateProfile;

public sealed record UpdateProfileCommand(
    Guid UserId,
    string? Name,
    string? LastName,
    string? UserName,
    DateTime? DateOfBirth,
    string? Biography) : IRequest<ErrorOr<Updated>>;