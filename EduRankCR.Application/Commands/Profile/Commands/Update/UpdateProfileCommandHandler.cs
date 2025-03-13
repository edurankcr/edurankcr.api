using EduRankCR.Application.Common;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.UserAggregate.Entities;
using EduRankCR.Domain.UserAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Profile.Commands.Update;

public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, ErrorOr<BoolResult>>
{
    private readonly IUserRepository _userRepository;

    public UpdateProfileCommandHandler(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<BoolResult>> Handle(
        UpdateProfileCommand query,
        CancellationToken cancellationToken)
    {
        if (new object?[] { query.Name, query.LastName, query.UserName, query.BirthDate, query.AvatarUrl, query.Biography }.All(value => value is null))
        {
            return Errors.General.NothingToUpdate;
        }

        UserId userId = new(new Guid(query.UserId));
        User? user = await _userRepository.FindById(userId);

        if (user is null)
        {
            return Errors.User.NotFound;
        }

        if (query.UserName is not null && query.UserName != user.UserName)
        {
            User? userWithSameUserName = await _userRepository.Find(query.UserName);

            if (userWithSameUserName is not null)
            {
                return Errors.User.UsernameTaken;
            }
        }

        await _userRepository.UpdateProfile(
            userId,
            query.Name,
            query.LastName,
            query.UserName,
            query.BirthDate,
            query.AvatarUrl,
            query.Biography);

        return new BoolResult(true);
    }
}