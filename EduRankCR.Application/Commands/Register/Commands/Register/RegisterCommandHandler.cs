using EduRankCR.Application.Common;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.Common.Interfaces.Auth;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.UserAggregate.Entities;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Register.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<BoolResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<ErrorOr<BoolResult>> Handle(
        RegisterCommand query,
        CancellationToken cancellationToken)
    {
        if (await _userRepository.Find(query.Email) is not null)
        {
            return Errors.User.EmailTaken;
        }

        if (await _userRepository.Find(query.UserName) is not null)
        {
            return Errors.User.UsernameTaken;
        }

        User user = User.Create(
            query.Name,
            query.LastName,
            query.UserName,
            query.Email,
            query.BirthDate,
            _passwordHasher.HashPassword(query.Password));

        await _userRepository.Create(user);

        return new BoolResult(true);
    }
}