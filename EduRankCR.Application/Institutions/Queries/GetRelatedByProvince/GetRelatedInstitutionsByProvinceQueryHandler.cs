using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Application.Institutions.Common;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Institutions.Queries.GetRelatedByProvince;

public sealed class GetRelatedInstitutionsByProvinceQueryHandler
    : IRequestHandler<GetRelatedInstitutionsByProvinceQuery, ErrorOr<List<InstitutionRelatedResult>>>
{
    private readonly IInstitutionRepository _repository;

    public GetRelatedInstitutionsByProvinceQueryHandler(IInstitutionRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<List<InstitutionRelatedResult>>> Handle(
        GetRelatedInstitutionsByProvinceQuery request,
        CancellationToken cancellationToken)
    {
        var institution = await _repository.GetById(request.InstitutionId);

        if (institution is null)
        {
            return Errors.Institution.NotFound;
        }

        var institutions = await _repository.GetRelatedByProvince(request.InstitutionId);

        if (institutions.Count == 0)
        {
            return new List<InstitutionRelatedResult>();
        }

        return institutions
            .Select(x => new InstitutionRelatedResult(
                x.InstitutionId,
                x.Name,
                x.Description,
                x.Province,
                x.Type,
                x.WebsiteUrl,
                x.OverallAverage,
                x.ReviewCount))
            .ToList();
    }
}