using EduRankCR.Application.Commands.Profile.Common;
using EduRankCR.Application.Common.Interfaces.Persistence;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.UserAggregate.Entities;
using EduRankCR.Domain.UserAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Profile.Queries.Profile;

public class ProfileQueryHandler : IRequestHandler<ProfileQuery, ErrorOr<ProfileResult>>
{
    private readonly IUserRepository _userRepository;

    public ProfileQueryHandler(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<ProfileResult>> Handle(ProfileQuery query, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.FindById(new UserId(new Guid(query.UserId)));

        if (user?.Id is null)
        {
            return Errors.User.NotFound;
        }

        return new ProfileResult(
            user);
    }
}