using EduRankCR.Application.Register.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Register.Commands.Register;

public record RegisterCommand(
    string Name,
    string LastName,
    string UserName,
    string Email,
    DateTime BirthDate,
    string Password) : IRequest<ErrorOr<RegisterResult>>;