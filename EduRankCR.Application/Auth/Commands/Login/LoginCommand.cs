using EduRankCR.Application.Auth.Common;

using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Auth.Commands.Login;

public record LoginCommand(
    string Identifier,
    string Password) : IRequest<ErrorOr<AuthResult>>;