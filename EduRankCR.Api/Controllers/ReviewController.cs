using EduRankCR.Application.Commands.Reviews.Queries;
using EduRankCR.Contracts.Reviews;

using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduRankCR.Api.Controllers;

[Route("reviews")]
[AllowAnonymous]
public class ReviewController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public ReviewController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetLastReviews()
    {
        var response = await _mediator.Send(new LastReviewsQuery());

        return response.Match(
            result => Ok(_mapper.Map<LastReviewsResponse>(result)),
            Problem);
    }
}