using EduRankCR.Application.Common;

using ErrorOr;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace EduRankCR.Application.Profile.Commands.Avatar;

public record ChangeAvatarCommand(
    IFormFile Avatar,
    string UserId) : IRequest<ErrorOr<BoolResult>>;