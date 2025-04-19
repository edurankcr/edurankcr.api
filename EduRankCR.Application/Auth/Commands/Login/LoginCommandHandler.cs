using EduRankCR.Application.Auth.Common;
using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Domain.Users.ValueObjects;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Auth.Commands.Login;

internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, ErrorOr<AuthResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPasswordHasher _passwordHasher;

    public LoginCommandHandler(
        IUserRepository authRepository,
        IJwtTokenGenerator jwtTokenGenerator,
        IPasswordHasher passwordHasher)
    {
        _userRepository = authRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordHasher = passwordHasher;
    }

    public async Task<ErrorOr<AuthResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdentifier(request.Identifier);

        if (user is null)
        {
            return Errors.User.NotFound;
        }

        if (!_passwordHasher.Verify(request.Password, user.Password))
        {
            return Errors.Auth.InvalidCredentials;
        }

        if (!user.EmailConfirmed)
        {
            return Errors.User.NotConfirmed;
        }

        var payload = new UserTokenPayload(
            user.UserId,
            user.Name,
            user.Email,
            user.Role);

        var token = _jwtTokenGenerator.GenerateToken(payload);

        return new AuthResult(
            UserId: user.UserId,
            Name: user.Name,
            LastName: user.LastName,
            UserName: user.UserName,
            Email: user.Email,
            EmailConfirmed: user.EmailConfirmed,
            NewEmail: user.NewEmail,
            Role: user.Role,
            Status: user.Status,
            AvatarUrl: user.AvatarUrl,
            Biography: user.Biography,
            BirthDate: user.BirthDate,
            CreatedAt: user.CreatedAt,
            UpdatedAt: user.UpdatedAt,
            Token: token);
    }
}