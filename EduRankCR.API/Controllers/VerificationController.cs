using EduRankCR.Application.Verification.Commands.EmailVerification;
using EduRankCR.Contracts.Verification;

using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduRankCR.Api.Controllers;

[Route("email")]
[AllowAnonymous]
public class VerificationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public VerificationController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("request")]
    public async Task<IActionResult> RequestEmailVerification(RequestEmailVerificationRequest request)
    {
        var command = _mapper.Map<RequestEmailVerificationCommand>(request);
        var result = await _mediator.Send(command);

        return result.Match(
            requestEmailVerificationResult => Ok(_mapper.Map<RequestEmailVerificationResponse>(requestEmailVerificationResult)),
            Problem);
    }

    [HttpGet("verify")]
    public async Task<IActionResult> VerifyEmailVerification([FromQuery] VerifyEmailVerificationRequest verifyEmailVerificationRequest)
    {
        var command = _mapper.Map<VerifyEmailVerificationCommand>(verifyEmailVerificationRequest);
        var result = await _mediator.Send(command);

        return result.Match(
            verifyEmailResult => Ok(_mapper.Map<VerifyEmailVerificationResponse>(verifyEmailResult)),
            Problem);
    }
}