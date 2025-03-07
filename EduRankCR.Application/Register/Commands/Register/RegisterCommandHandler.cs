﻿using EduRankCR.Application.Common.Interfaces.Auth;
using EduRankCR.Application.Common.Interfaces.Persistence;
using EduRankCR.Application.Register.Common;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.UserAggregate.Entities;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Register.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<RegisterResult>>
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

    public async Task<ErrorOr<RegisterResult>> Handle(
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

        return new RegisterResult(true);
    }
}