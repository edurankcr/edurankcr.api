using EduRankCR.Application.Commands.Profile.Commands.Avatar.Change;
using EduRankCR.Application.Commands.Profile.Commands.Email.Change;
using EduRankCR.Application.Commands.Profile.Commands.Email.Verify;
using EduRankCR.Application.Commands.Profile.Commands.Update;
using EduRankCR.Application.Commands.Profile.Queries.Profile;
using EduRankCR.Contracts.Common;
using EduRankCR.Contracts.Profile;
using EduRankCR.Domain.Common.Errors;
using MapsterMapper;
using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduRankCR.Api.Controllers;

[Route("profile")]
public class ProfileController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public ProfileController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        var userId = GetUserId();

        if (userId is null)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: Errors.Auth.Unauthorized.Description);
        }

        var query = new ProfileQuery(userId);
        var profileResult = await _mediator.Send(query);

        return profileResult.Match(
            result => Ok(_mapper.Map<ProfileResponse>(result)),
            Problem);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateProfile(UpdateProfileRequest request)
    {
        var userId = GetUserId();

        if (userId is null)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: Errors.Auth.Unauthorized.Description);
        }

        var command = _mapper.Map<UpdateProfileCommand>(request) with { UserId = userId };
        var updateResult = await _mediator.Send(command);

        return updateResult.Match(
            result => Ok(_mapper.Map<BoolResponse>(result)),
            Problem);
    }

    [HttpPut("change-email")]
    public async Task<IActionResult> ChangeEmail(ChangeEmailRequest request)
    {
        var userId = GetUserId();

        if (userId is null)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: Errors.Auth.Unauthorized.Description);
        }

        var command = _mapper.Map<ChangeEmailProfileCommand>(request) with { UserId = userId };
        var changeEmailResult = await _mediator.Send(command);

        return changeEmailResult.Match(
            result => Ok(_mapper.Map<BoolResponse>(result)),
            Problem);
    }

    [HttpGet("verify-change-email")]
    [AllowAnonymous]
    public async Task<IActionResult> VerifyChangeEmail([FromQuery] VerifyChangeEmailRequest request)
    {
        var command = _mapper.Map<VerifyEmailProfileCommand>(request);
        var verifyChangeEmailResult = await _mediator.Send(command);

        return verifyChangeEmailResult.Match(
            result => Ok(_mapper.Map<BoolResponse>(result)),
            Problem);
    }

    [HttpPut("change-avatar")]
    public async Task<IActionResult> ChangeAvatar([FromForm] ChangeAvatarRequest request)
    {
        var userId = GetUserId();

        if (userId is null)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: Errors.Auth.Unauthorized.Description);
        }

        var command = new ChangeAvatarProfileCommand(request.Avatar, userId);
        var changeAvatarResult = await _mediator.Send(command);

        return changeAvatarResult.Match(
            result => Ok(_mapper.Map<BoolResponse>(result)),
            Problem);
    }
}