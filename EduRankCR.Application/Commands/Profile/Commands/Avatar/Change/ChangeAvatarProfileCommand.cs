using EduRankCR.Application.Common;

using ErrorOr;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace EduRankCR.Application.Commands.Profile.Commands.Avatar.Change;

public record ChangeAvatarProfileCommand(
    IFormFile Avatar,
    string UserId) : IRequest<ErrorOr<BoolResult>>;