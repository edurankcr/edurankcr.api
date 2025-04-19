using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Domain.Users;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Auth.Commands.Register;

internal sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ErrorOr<Created>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<ErrorOr<Created>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var exists = await _userRepository.GetExistingIdentifier(request.Email, request.UserName);

        if (exists is not null)
        {
            switch (exists)
            {
                case "Email":
                    return Errors.User.DuplicateEmail;
                default:
                    return Errors.User.DuplicateUserName;
            }
        }

        var passwordHash = _passwordHasher.Hash(request.Password);

        var user = User.Create(request.Name, request.LastName, request.UserName, request.Email, passwordHash, request.BirthDate);

        await _userRepository.Create(user);

        return Result.Created;
    }
}