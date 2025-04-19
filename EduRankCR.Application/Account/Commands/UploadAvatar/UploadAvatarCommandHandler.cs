using EduRankCR.Application.Account.Common;
using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;

using ErrorOr;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace EduRankCR.Application.Account.Commands.UploadAvatar;

internal sealed class UploadAvatarCommandHandler : IRequestHandler<UploadAvatarCommand, ErrorOr<UploadAvatarResult>>
{
    private readonly IStorageService _storageService;
    private readonly IUserRepository _userRepository;

    public UploadAvatarCommandHandler(
        IStorageService storageService,
        IUserRepository userRepository)
    {
        _storageService = storageService;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UploadAvatarResult>> Handle(UploadAvatarCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.UserId);

        if (user is null)
        {
            return Errors.User.NotFound;
        }

        if (!user.EmailConfirmed)
        {
            return Errors.User.NotConfirmed;
        }

        string fileName = user.UserId + Path.GetExtension(request.File.FileName);
        var avatarUrl = await _storageService.AvatarUpload(request.File, fileName);

        if (avatarUrl is null)
        {
            return Errors.Storage.UploadFailed;
        }

        await _userRepository.UpdateAvatar(request.UserId, avatarUrl);

        return new UploadAvatarResult(avatarUrl);
    }
}