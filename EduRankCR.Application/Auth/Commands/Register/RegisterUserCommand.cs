using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Auth.Commands.Register;

public sealed record RegisterUserCommand(
    string Name,
    string LastName,
    string UserName,
    string Email,
    DateTime BirthDate,
    string Password) : IRequest<ErrorOr<Created>>;