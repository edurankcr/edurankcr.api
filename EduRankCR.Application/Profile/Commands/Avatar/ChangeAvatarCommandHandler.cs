using EduRankCR.Application.Common;
using EduRankCR.Application.Common.Interfaces.Persistence;
using EduRankCR.Application.Common.Interfaces.Services;
using EduRankCR.Application.Profile.Commands.Email;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.TokenAggregate.Entities;
using EduRankCR.Domain.UserAggregate.Entities;
using EduRankCR.Domain.UserAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Profile.Commands.Avatar;

public class ChangeAvatarCommandHandler : IRequestHandler<ChangeAvatarCommand, ErrorOr<BoolResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IStorageService _storageService;

    public ChangeAvatarCommandHandler(
        IUserRepository userRepository,
        IStorageService storageService)
    {
        _userRepository = userRepository;
        _storageService = storageService;
    }

    public async Task<ErrorOr<BoolResult>> Handle(
        ChangeAvatarCommand query,
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

        return new BoolResult(true);
    }
}