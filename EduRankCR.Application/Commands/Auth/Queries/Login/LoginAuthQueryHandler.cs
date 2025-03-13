using EduRankCR.Application.Commands.Auth.Common;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.Common.Interfaces.Auth;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.UserAggregate.Entities;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Auth.Queries.Login;

public class LoginAuthQueryHandler : IRequestHandler<LoginAuthQuery, ErrorOr<LoginResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public LoginAuthQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository,
        IPasswordHasher passwordHasher)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<ErrorOr<LoginResult>> Handle(LoginAuthQuery authQuery, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.Find(authQuery.Identifier);

        if (user?.Id is null)
        {
            return Errors.User.NotFound;
        }

        if (_passwordHasher.VerifyPassword(authQuery.Password, user.Password) is false)
        {
            return Errors.Auth.InvalidCredentials;
        }

        if (user.EmailConfirmed is false)
        {
            return Errors.User.EmailNotConfirmed;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new LoginResult(
            user,
            token);
    }
}