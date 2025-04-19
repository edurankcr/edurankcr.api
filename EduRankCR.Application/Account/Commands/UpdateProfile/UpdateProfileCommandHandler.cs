using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Account.Commands.UpdateProfile;

internal sealed class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, ErrorOr<Updated>>
{
    private readonly IUserRepository _userRepository;

    public UpdateProfileCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Updated>> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        if (new object?[] { request.Name, request.LastName, request.UserName, request.DateOfBirth, request.Biography }.All(x => x is null))
        {
            return Errors.User.NullInformation;
        }

        var user = await _userRepository.GetById(request.UserId);

        if (user is null)
        {
            return Errors.User.NotFound;
        }

        if (!user.EmailConfirmed)
        {
            return Errors.User.NotConfirmed;
        }

        if (request.UserName is not null)
        {
            if (user.UserName == request.UserName)
            {
                return Errors.User.SameUserName;
            }

            var exists = await _userRepository.IsUserNameTaken(request.UserName);

            if (exists)
            {
                return Errors.User.DuplicateUserName;
            }
        }

        await _userRepository.UpdateProfile(
            request.UserId,
            request.Name,
            request.LastName,
            request.UserName,
            request.DateOfBirth,
            request.Biography);

        return Result.Updated;
    }
}