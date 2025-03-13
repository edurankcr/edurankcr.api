using EduRankCR.Application.Commands.Search.Queries;
using EduRankCR.Contracts.Search;
using MapsterMapper;
using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduRankCR.Api.Controllers;

[Route("search")]
public class SearchController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public SearchController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Search([FromQuery] SearchRequest request)
    {
        var command = _mapper.Map<SearchQuery>(request);
        var response = await _mediator.Send(command);

        return response.Match(
            result => Ok(_mapper.Map<SearchResponse>(result)),
            Problem);
    }
}