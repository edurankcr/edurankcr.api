using EduRankCR.Application.Account.Common;

using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EduRankCR.Application.Account.Commands.UploadAvatar;

public sealed record UploadAvatarCommand(Guid UserId, IFormFile File) : IRequest<ErrorOr<UploadAvatarResult>>;