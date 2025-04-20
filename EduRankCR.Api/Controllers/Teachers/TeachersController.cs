using EduRankCR.Api.Common.Http;
using EduRankCR.Api.Controllers.Common;
using EduRankCR.Application.Teachers.Commands.Create;
using EduRankCR.Application.Teachers.Queries.GetById;
using EduRankCR.Contracts.Teachers.Requests;
using EduRankCR.Contracts.Teachers.Responses;

using Mapster;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduRankCR.Api.Controllers.Teachers;

[Route("teachers")]
public class TeachersController : BaseApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public TeachersController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTeacherRequest request)
    {
        var userId = HttpContext.GetUserId();

        var command = request.Adapt<CreateTeacherCommand>() with { UserId = userId };
        var result = await _mediator.Send(command);

        return result.Match(
            value => Ok(_mapper.Map<TeacherResponse>(value)),
            Problem);
    }

    [HttpGet("{teacherId:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(Guid teacherId)
    {
        var query = new GetTeacherByIdQuery(teacherId);
        var result = await _mediator.Send(query);

        return result.Match(
            value => Ok(_mapper.Map<TeacherResponse>(value)),
            Problem);
    }
}