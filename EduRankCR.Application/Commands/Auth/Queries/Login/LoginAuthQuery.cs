using EduRankCR.Application.Commands.Auth.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Auth.Queries.Login;

public record LoginAuthQuery(
    string Identifier,
    string Password) : IRequest<ErrorOr<LoginResult>>;