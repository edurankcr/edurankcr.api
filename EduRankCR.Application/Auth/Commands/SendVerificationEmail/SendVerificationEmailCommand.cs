using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Auth.Commands.SendVerificationEmail;

public record SendVerificationEmailCommand(string Email) : IRequest<ErrorOr<Unit>>;