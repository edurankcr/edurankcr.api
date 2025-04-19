using EduRankCR.Api.Controllers.Common;
using EduRankCR.Application.Institutions.Queries.GetInstitutionById;
using EduRankCR.Contracts.Institutions;

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

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _mediator.Send(new GetInstitutionByIdQuery(id));

        return result.Match(
            institution => Ok(_mapper.Map<InstitutionBasicInfoResponse>(institution)),
            Problem);
    }
}