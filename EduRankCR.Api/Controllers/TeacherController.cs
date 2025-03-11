using EduRankCR.Application.Commands.Teacher.Commands.Create;
using EduRankCR.Contracts.Common;
using EduRankCR.Contracts.Teacher;
using EduRankCR.Domain.Common.Errors;
using MapsterMapper;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace EduRankCR.Api.Controllers;

[Route("teacher")]
public class TeacherController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public TeacherController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTeacherRequest request)
    {
        var userId = GetUserId();

        if (userId is null)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: Errors.Auth.Unauthorized.Description);
        }

        var command = _mapper.Map<CreateTeacherCommand>(request) with { UserId = userId };
        var response = await _mediator.Send(command);

        return response.Match(
            result => Ok(_mapper.Map<BoolResponse>(result)),
            Problem);
    }
}