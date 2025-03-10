using EduRankCR.Application.Commands.Password.Commands.Change;
using EduRankCR.Application.Commands.Password.Commands.Forgot;
using EduRankCR.Application.Commands.Password.Commands.Reset;
using EduRankCR.Application.Common;
using EduRankCR.Contracts.Common;
using EduRankCR.Contracts.Password;
using EduRankCR.Domain.Common.Errors;

using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduRankCR.Api.Controllers;

[Route("password")]
public class PasswordController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public PasswordController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("forgot")]
    [AllowAnonymous]
    public async Task<IActionResult> Forgot(ForgotRequest request)
    {
        var command = _mapper.Map<ForgotPasswordCommand>(request);
        ErrorOr<BoolResult> forgotResult = await _mediator.Send(command);

        return forgotResult.Match(
            result => Ok(_mapper.Map<BoolResponse>(result)),
            Problem);
    }

    [HttpPost("reset")]
    [AllowAnonymous]
    public async Task<IActionResult> Reset(ResetRequest request)
    {
        var command = _mapper.Map<ResetPasswordCommand>(request);
        ErrorOr<BoolResult> resetResult = await _mediator.Send(command);

        return resetResult.Match(
            result => Ok(_mapper.Map<BoolResponse>(result)),
            Problem);
    }

    [HttpPost("change")]
    [Authorize]
    public async Task<IActionResult> Change(ChangeRequest request)
    {
        var userId = GetUserId();

        if (userId is null)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: Errors.Auth.Unauthorized.Description);
        }

        var command = _mapper.Map<ChangePasswordCommand>(request) with { UserId = userId };

        ErrorOr<BoolResult> changeResult = await _mediator.Send(command);

        return changeResult.Match(
            result => Ok(_mapper.Map<BoolResponse>(result)),
            Problem);
    }
}