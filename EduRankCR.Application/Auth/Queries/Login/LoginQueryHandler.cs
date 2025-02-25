using EduRankCR.Application.Auth.Common;
using EduRankCR.Application.Common.Interfaces.Auth;
using EduRankCR.Application.Common.Interfaces.Persistence;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.UserAggregate.Entities;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Auth.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<LoginResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository,
        IPasswordHasher passwordHasher)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<ErrorOr<LoginResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.Find(query.Identifier);

        if (user?.Id is null)
        {
            return Errors.User.NotFound;
        }

        if (_passwordHasher.VerifyPassword(query.Password, user.Password) is false)
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