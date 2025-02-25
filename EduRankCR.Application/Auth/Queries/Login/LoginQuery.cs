using EduRankCR.Application.Auth.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Auth.Queries.Login;

public record LoginQuery(
    string Identifier,
    string Password) : IRequest<ErrorOr<LoginResult>>;