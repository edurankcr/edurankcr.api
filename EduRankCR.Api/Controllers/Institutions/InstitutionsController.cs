using EduRankCR.Api.Common.Http;
using EduRankCR.Api.Controllers.Common;
using EduRankCR.Application.Institutions.Commands.Create;
using EduRankCR.Application.Institutions.Queries.GetAggregateRatings;
using EduRankCR.Application.Institutions.Queries.GetById;
using EduRankCR.Application.Institutions.Queries.GetRatings;
using EduRankCR.Application.Institutions.Queries.GetRelatedByProvince;
using EduRankCR.Contracts.Institutions.Requests;
using EduRankCR.Contracts.Institutions.Responses;

using Mapster;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduRankCR.Api.Controllers.Institutions;

[Route("institutions")]
public class InstitutionsController : BaseApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public InstitutionsController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{institutionId:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(Guid institutionId)
    {
        var query = new GetInstitutionByIdQuery(institutionId);
        var result = await _mediator.Send(query);

        return result.Match(
            value => Ok(_mapper.Map<InstitutionResponse>(value)),
            Problem);
    }

    [HttpGet("{institutionId:guid}/ratings")]
    [AllowAnonymous]
    public async Task<IActionResult> GetRatingsByInstitutionId(Guid institutionId)
    {
        var query = new GetRatingsByInstitutionIdQuery(institutionId);
        var result = await _mediator.Send(query);

        return result.Match(
            value => Ok(_mapper.Map<List<InstitutionRatingResponse>>(value)),
            Problem);
    }

    [HttpGet("{institutionId:guid}/ratings/aggregate")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAggregateRatingsByInstitutionId(Guid institutionId)
    {
        var query = new GetAggregateRatingsByInstitutionIdQuery(institutionId);
        var result = await _mediator.Send(query);

        return result.Match(
            value => Ok(_mapper.Map<InstitutionRatingAggregateResponse>(value)),
            Problem);
    }

    [HttpGet("{institutionId:guid}/related")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(List<InstitutionRelatedResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRelatedInstitutions(Guid institutionId)
    {
        var query = new GetRelatedInstitutionsByProvinceQuery(institutionId);
        var result = await _mediator.Send(query);

        return result.Match(
            value => Ok(_mapper.Map<List<InstitutionRelatedResponse>>(value)),
            Problem);
    }

    [HttpPost]
    public async Task<IActionResult> CreateInstitution([FromBody] CreateInstitutionRequest request)
    {
        var userId = HttpContext.GetUserId();

        var command = request.Adapt<CreateInstitutionCommand>() with { UserId = userId };
        var result = await _mediator.Send(command);

        return result.Match(
            value => Ok(_mapper.Map<CreateInstitutionResponse>(value)),
            Problem);
    }
}