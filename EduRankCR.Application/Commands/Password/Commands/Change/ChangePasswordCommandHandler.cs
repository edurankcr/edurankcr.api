using EduRankCR.Application.Common;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.Common.Interfaces.Auth;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.UserAggregate.Entities;
using EduRankCR.Domain.UserAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Password.Commands.Change;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ErrorOr<BoolResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public ChangePasswordCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<ErrorOr<BoolResult>> Handle(
        ChangePasswordCommand query,
        CancellationToken cancellationToken)
    {
        User? user = await _userRepository.FindById(new UserId(new Guid(query.UserId)));

        if (user?.Id is null)
        {
            return Errors.User.NotFound;
        }

        if (_passwordHasher.VerifyPassword(query.CurrentPassword, user.Password) is false)
        {
            return Errors.Auth.InvalidCredentials;
        }

        await _userRepository.UpdatePassword(user.Id, _passwordHasher.HashPassword(query.NewPassword));

        return new BoolResult(true);
    }
}