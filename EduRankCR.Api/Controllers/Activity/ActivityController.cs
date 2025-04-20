using EduRankCR.Api.Controllers.Common;
using EduRankCR.Application.Activity.Queries.GetLastActivity;
using EduRankCR.Contracts.Activity.Responses;

using MapsterMapper;
using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduRankCR.Api.Controllers.Activity;

[Route("activity")]
[AllowAnonymous]
public class ActivityController : BaseApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public ActivityController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("latest")]
    [ProducesResponseType(typeof(LastActivityResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLatest()
    {
        var command = new GetLastActivityQuery();
        var result = await _mediator.Send(command);

        return result.Match(
            value => Ok(_mapper.Map<LastActivityResponse>(value)),
            Problem);
    }
}