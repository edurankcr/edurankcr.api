using EduRankCR.Application.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Register.Commands.Register;

public record RegisterCommand(
    string Name,
    string LastName,
    string UserName,
    string Email,
    DateTime BirthDate,
    string Password) : IRequest<ErrorOr<BoolResult>>;