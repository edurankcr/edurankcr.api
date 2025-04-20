using EduRankCR.Api.Controllers.Common;
using EduRankCR.Application.Institutions.Queries.GetLatestRatings;
using EduRankCR.Contracts.Institutions.Responses;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduRankCR.Api.Controllers.Institutions;

[Route("institutions/ratings")]
public class InstitutionRatingsController : BaseApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public InstitutionRatingsController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("latest")]
    [AllowAnonymous]
    public async Task<IActionResult> GetLatestRatings()
    {
        var result = await _mediator.Send(new GetLatestInstitutionRatingsQuery());

        return result.Match(
            ratings => Ok(_mapper.Map<GetLatestInstitutionRatingsResponse>(ratings)),
            Problem);
    }
}