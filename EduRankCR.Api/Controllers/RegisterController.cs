using EduRankCR.Application.Register.Commands.Register;
using EduRankCR.Application.Register.Common;
using EduRankCR.Application.Verification.Commands.EmailVerification;
using EduRankCR.Contracts.Register;
using EduRankCR.Contracts.Verification;

using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduRankCR.Api.Controllers;

[Route("register")]
[AllowAnonymous]
public class RegisterController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public RegisterController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<RegisterResult> regResult = await _mediator.Send(command);

        return regResult.Match(
            registrationResult => Ok(_mapper.Map<RegisterResponse>(registrationResult)),
            Problem);
    }
}