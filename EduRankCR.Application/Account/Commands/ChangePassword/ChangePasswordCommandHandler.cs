using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Account.Commands.ChangePassword;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ErrorOr<Unit>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public ChangePasswordCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordService;
    }

    public async Task<ErrorOr<Unit>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
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

        var passwordIsValid = _passwordHasher.Verify(request.CurrentPassword, user.Password);

        if (!passwordIsValid)
        {
            return Errors.User.InvalidPassword;
        }

        await _userRepository.UpdatePassword(user.UserId, _passwordHasher.Hash(request.NewPassword));

        return Unit.Value;
    }
}