using EduRankCR.Application.Commands.Register.Commands.Register;
using EduRankCR.Application.Common;
using EduRankCR.Contracts.Register;

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
        ErrorOr<BoolResult> response = await _mediator.Send(command);

        return response.Match(
            registrationResult => Ok(_mapper.Map<RegisterResponse>(registrationResult)),
            Problem);
    }
}