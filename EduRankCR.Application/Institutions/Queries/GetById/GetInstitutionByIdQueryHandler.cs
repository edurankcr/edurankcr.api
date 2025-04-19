using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Application.Institutions.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Institutions.Queries.GetById;

internal sealed class GetInstitutionByIdQueryHandler : IRequestHandler<GetInstitutionByIdQuery, ErrorOr<InstitutionResult>>
{
    private readonly IInstitutionRepository _repository;

    public GetInstitutionByIdQueryHandler(IInstitutionRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<InstitutionResult>> Handle(GetInstitutionByIdQuery request, CancellationToken cancellationToken)
    {
        var institution = await _repository.GetById(request.InstitutionId);

        if (institution is null)
        {
            return Errors.Institution.NotFound;
        }

        return new InstitutionResult(
            institution.InstitutionId,
            institution.Name,
            institution.Description,
            institution.Province,
            (byte)institution.Type,
            institution.WebsiteUrl,
            institution.AiReviewSummary,
            institution.CreatedAt,
            institution.UpdatedAt,
            (byte)institution.Status);
    }
}