using EduRankCR.Application.Auth.Queries.Login;
using EduRankCR.Contracts.Auth;
using EduRankCR.Domain.Common.Errors;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduRankCR.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        var authResult = await _mediator.Send(query);

        if (authResult.IsError && authResult.FirstError == Errors.Auth.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: Errors.Auth.InvalidCredentials.Description);
        }

        return authResult.Match(
            authenticationResult => Ok(_mapper.Map<LoginResponse>(authenticationResult)),
            Problem);
    }

    // TODO: logout, refresh
}