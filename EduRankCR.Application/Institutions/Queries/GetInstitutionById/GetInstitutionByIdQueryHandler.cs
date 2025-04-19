using EduRankCR.Application.Common.Errors;
using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Application.Institutions.Common;

using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Institutions.Queries.GetInstitutionById;

public sealed class GetInstitutionByIdQueryHandler : IRequestHandler<GetInstitutionByIdQuery, ErrorOr<InstitutionBasicInfoResult>>
{
    private readonly IInstitutionRepository _institutionRepository;

    public GetInstitutionByIdQueryHandler(IInstitutionRepository institutionRepository)
    {
        _institutionRepository = institutionRepository;
    }

    public async Task<ErrorOr<InstitutionBasicInfoResult>> Handle(GetInstitutionByIdQuery request, CancellationToken cancellationToken)
    {
        var institution = await _institutionRepository.GetById(request.InstitutionId);

        if (institution is null)
        {
            return Errors.Institution.NotFound;
        }

        return institution;
    }
}