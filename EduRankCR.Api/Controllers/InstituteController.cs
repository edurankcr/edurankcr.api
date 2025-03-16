using EduRankCR.Application.Commands.Institute.Commands.Create;
using EduRankCR.Application.Commands.Institute.Commands.Update;
using EduRankCR.Application.Commands.Institute.Common;
using EduRankCR.Application.Commands.Institute.Query.Search;
using EduRankCR.Application.Commands.Teacher.Commands.Create;
using EduRankCR.Application.Commands.Teacher.Commands.Update;
using EduRankCR.Contracts.Common;
using EduRankCR.Contracts.Institute;
using EduRankCR.Contracts.Teacher;
using EduRankCR.Domain.Common.Errors;
using MapsterMapper;
using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduRankCR.Api.Controllers;

[Route("institute")]
public class InstituteController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public InstituteController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateInstituteRequest request)
    {
        var userId = GetUserId();

        if (userId is null)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: Errors.Auth.Unauthorized.Description);
        }

        var command = _mapper.Map<CreateInstituteCommand>(request) with { UserId = userId };
        var response = await _mediator.Send(command);

        return response.Match(
            result => Ok(_mapper.Map<BoolResponse>(result)),
            Problem);
    }

    [HttpGet("search")]
    [AllowAnonymous]
    public async Task<IActionResult> Search([FromQuery] SearchInstituteRequest request)
    {
        var command = _mapper.Map<SearchInstituteQuery>(request);
        var response = await _mediator.Send(command);

        return response.Match(
            result => Ok(_mapper.Map<SearchInstituteResponse>(result)),
            Problem);
    }

    [HttpPost("{instituteId:required}/review")]
    public async Task<IActionResult> Create(string instituteId, CreateReviewInstituteRequest request)
    {
        var userId = GetUserId();

        if (userId is null)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: Errors.Auth.Unauthorized.Description);
        }

        var command = _mapper.Map<CreateReviewInstituteCommand>(request) with { UserId = userId, InstituteId = instituteId };
        var response = await _mediator.Send(command);

        return response.Match(
            result => Ok(_mapper.Map<BoolResponse>(result)),
            Problem);
    }

    [HttpPut("{instituteId:required}/review")]
    public async Task<IActionResult> Update(string instituteId, UpdateReviewInstituteRequest request)
    {
        var userId = GetUserId();

        if (userId is null)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: Errors.Auth.Unauthorized.Description);
        }

        var command = _mapper.Map<UpdateReviewInstituteCommand>(request) with { UserId = userId, InstituteId = instituteId };
        var response = await _mediator.Send(command);

        return response.Match(
            result => Ok(_mapper.Map<BoolResponse>(result)),
            Problem);
    }
}