using EduRankCR.Api.Common.Http;
using EduRankCR.Api.Controllers.Common;
using EduRankCR.Application.Account.Commands.ChangeEmail;
using EduRankCR.Application.Account.Commands.ChangePassword;
using EduRankCR.Application.Account.Commands.DeleteAvatar;
using EduRankCR.Application.Account.Commands.DeleteEmailChange;
using EduRankCR.Application.Account.Commands.UpdateProfile;
using EduRankCR.Application.Account.Commands.UploadAvatar;
using EduRankCR.Application.Account.Commands.VerifyEmailChange;
using EduRankCR.Application.Account.Queries.GetAccount;
using EduRankCR.Contracts.Account;

using Mapster;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduRankCR.Api.Controllers.Account;

[Route("account")]
public class AccountController : BaseApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AccountController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPut("password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        var userId = HttpContext.GetUserId();

        var command = request.Adapt<ChangePasswordCommand>() with { UserId = userId };
        var result = await _mediator.Send(command);

        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetAccount()
    {
        var userId = HttpContext.GetUserId();
        var result = await _mediator.Send(new GetAccountQuery(userId));

        return result.Match(
            user => Ok(_mapper.Map<UserResponse>(user)),
            Problem);
    }

    [HttpPut("profile")]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequest request)
    {
        var userId = HttpContext.GetUserId();

        var command = request.Adapt<UpdateProfileCommand>() with { UserId = userId };
        var result = await _mediator.Send(command);

        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpPut("email")]
    public async Task<IActionResult> ChangeEmail([FromBody] ChangeEmailRequest request)
    {
        var userId = HttpContext.GetUserId();

        var command = request.Adapt<ChangeEmailCommand>() with { UserId = userId };
        var result = await _mediator.Send(command);

        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpPost("email/verify")]
    [AllowAnonymous]
    public async Task<IActionResult> VerifyEmailChange([FromBody] VerifyEmailChangeRequest request)
    {
        var command = request.Adapt<VerifyEmailChangeCommand>();
        var result = await _mediator.Send(command);

        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpDelete("email")]
    public async Task<IActionResult> DeleteEmailChange()
    {
        var userId = HttpContext.GetUserId();

        var command = new DeleteEmailChangeCommand(userId);
        var result = await _mediator.Send(command);

        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpPost("avatar")]
    [ProducesResponseType(typeof(UploadAvatarResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> UploadAvatar([FromForm] UploadAvatarRequest request)
    {
        var userId = HttpContext.GetUserId();

        var command = new UploadAvatarCommand(userId, request.File);
        var result = await _mediator.Send(command);

        return result.Match(
            response => Ok(response.Adapt<UploadAvatarResponse>()),
            Problem);
    }

    [HttpDelete("avatar")]
    public async Task<IActionResult> DeleteAvatar()
    {
        var userId = HttpContext.GetUserId();

        var command = new DeleteAvatarCommand(userId);
        var result = await _mediator.Send(command);

        return result.Match(
            _ => NoContent(),
            Problem);
    }
}