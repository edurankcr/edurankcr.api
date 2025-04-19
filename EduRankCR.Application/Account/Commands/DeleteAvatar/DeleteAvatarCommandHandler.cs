using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Account.Commands.DeleteAvatar;

public sealed class DeleteAvatarCommandHandler : IRequestHandler<DeleteAvatarCommand, ErrorOr<Success>>
{
    private readonly IStorageService _storageService;
    private readonly IUserRepository _userRepository;

    public DeleteAvatarCommandHandler(IStorageService storageService, IUserRepository userRepository)
    {
        _storageService = storageService;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Success>> Handle(DeleteAvatarCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetProfileById(request.UserId);

        if (user is null)
        {
            return Errors.User.NotFound;
        }

        if (user.AvatarUrl is null)
        {
            return Errors.User.AvatarNotFound;
        }

        string fileName = user.UserId + Path.GetExtension(user.AvatarUrl);

        await _storageService.DeleteAvatar(fileName);

        await _userRepository.UpdateAvatar(user.UserId, null);

        return Result.Success;
    }
}