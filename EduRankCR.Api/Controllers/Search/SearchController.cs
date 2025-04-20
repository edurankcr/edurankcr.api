using EduRankCR.Api.Controllers.Common;
using EduRankCR.Application.Search.Queries.SearchByName;
using EduRankCR.Contracts.Search.Responses;

using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduRankCR.Api.Controllers.Search;

[Route("search")]
public class SearchController : BaseApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public SearchController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> SearchByName([FromQuery] string name)
    {
        var command = new SearchByNameQuery(name);
        var result = await _mediator.Send(command);

        return result.Match(
            value => Ok(_mapper.Map<SearchResponse>(value)),
            Problem);
    }
}