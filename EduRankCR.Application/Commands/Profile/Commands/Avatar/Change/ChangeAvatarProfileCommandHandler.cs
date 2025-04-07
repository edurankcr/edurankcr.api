using EduRankCR.Application.Commands.Profile.Common;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.Common.Interfaces.Services;
using EduRankCR.Domain.UserAggregate.Entities;
using EduRankCR.Domain.UserAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Profile.Commands.Avatar.Change;

public class ChangeAvatarProfileCommandHandler : IRequestHandler<ChangeAvatarProfileCommand, ErrorOr<AvatarResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IStorageService _storageService;

    public ChangeAvatarProfileCommandHandler(
        IUserRepository userRepository,
        IStorageService storageService)
    {
        _userRepository = userRepository;
        _storageService = storageService;
    }

    public async Task<ErrorOr<AvatarResult>> Handle(
        ChangeAvatarProfileCommand query,
        CancellationToken cancellationToken)
    {
        UserId userId = new(new Guid(query.UserId));
        User? user = await _userRepository.FindById(userId);

        if (user is null)
        {
            return Errors.User.NotFound;
        }

        string fileName = userId.Value + Path.GetExtension(query.Avatar.FileName);
        string? avatarUrl = await _storageService.AvatarUpload(query.Avatar, fileName);

        if (avatarUrl is null)
        {
            return Errors.Storage.UploadFailed;
        }

        await _userRepository.UpdateAvatar(userId, avatarUrl);

        return new AvatarResult(avatarUrl);
    }
}