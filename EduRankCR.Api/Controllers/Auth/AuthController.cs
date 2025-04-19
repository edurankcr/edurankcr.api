using EduRankCR.Api.Controllers.Common;
using EduRankCR.Application.Auth.Commands.ConfirmVerificationEmail;
using EduRankCR.Application.Auth.Commands.Login;
using EduRankCR.Application.Auth.Commands.Register;
using EduRankCR.Application.Auth.Commands.RequestPasswordReset;
using EduRankCR.Application.Auth.Commands.ResetPassword;
using EduRankCR.Application.Auth.Commands.SendVerificationEmail;
using EduRankCR.Contracts.Auth;
using EduRankCR.Contracts.Auth.Requests;
using EduRankCR.Contracts.Auth.Responses;

using Mapster;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduRankCR.Api.Controllers.Auth;

[Route("auth")]
[AllowAnonymous]
public class AuthController : BaseApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var command = request.Adapt<LoginCommand>();
        var result = await _mediator.Send(command);

        return result.Match(
            authResult => Ok(authResult.Adapt<AuthResponse>()),
            Problem);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        var command = _mapper.Map<RegisterUserCommand>(request);
        var result = await _mediator.Send(command);

        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpPost("email/send-verification")]
    public async Task<IActionResult> SendVerificationEmail(SendVerificationEmailRequest request)
    {
        var command = request.Adapt<SendVerificationEmailCommand>();
        var result = await _mediator.Send(command);

        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpPost("email/confirm-verification")]
    public async Task<IActionResult> ConfirmVerificationEmail([FromBody] ConfirmVerificationEmailRequest request)
    {
        var command = request.Adapt<ConfirmVerificationEmailCommand>();
        var result = await _mediator.Send(command);

        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpPost("password/reset-request")]
    public async Task<IActionResult> RequestPasswordReset([FromBody] RequestPasswordReset request)
    {
        var command = request.Adapt<RequestPasswordResetCommand>();
        var result = await _mediator.Send(command);

        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpPost("password/reset")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
    {
        var command = request.Adapt<ResetPasswordCommand>();
        var result = await _mediator.Send(command);

        return result.Match(
            _ => NoContent(),
            Problem);
    }
}