using EduRankCR.Application.Commands.Profile.Commands.Email.Verify;
using EduRankCR.Application.Common;
using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.TokenAggregate.Entities;
using EduRankCR.Domain.TokenAggregate.ValueObjects;
using EduRankCR.Domain.UserAggregate.Entities;
using EduRankCR.Domain.UserAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Profile.Commands.Email.Delete;

public class DeleteEmailChangeProfileCommandHandler : IRequestHandler<DeleteEmailChangeProfileCommand, ErrorOr<BoolResult>>
{
    private readonly IUserRepository _userRepository;

    public DeleteEmailChangeProfileCommandHandler(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<BoolResult>> Handle(
        DeleteEmailChangeProfileCommand query,
        CancellationToken cancellationToken)
    {
        UserId userId = UserId.ConvertFromString(query.UserId);
        User? user = await _userRepository.FindById(userId);

        if (user is null)
        {
            return Errors.User.NotFound;
        }

        await _userRepository.DeleteChangeEmail(userId);

        return new BoolResult(true);
    }
}