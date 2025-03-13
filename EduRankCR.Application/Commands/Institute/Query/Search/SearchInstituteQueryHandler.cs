using EduRankCR.Application.Commands.Institute.Common;
using EduRankCR.Domain.Common.Errors;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.InstituteAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Institute.Query.Search;

public class SearchInstituteQueryHandler : IRequestHandler<SearchInstituteQuery, ErrorOr<SearchInstituteResult>>
{
    private readonly IInstituteRepository _instituteRepository;

    public SearchInstituteQueryHandler(IInstituteRepository instituteRepository)
    {
        _instituteRepository = instituteRepository;
    }

    public async Task<ErrorOr<SearchInstituteResult>> Handle(
        SearchInstituteQuery query,
        CancellationToken cancellationToken)
    {
        Domain.InstituteAggregate.Entities.Institute? institute = await _instituteRepository.Find(InstituteId.ConvertFromString(query.InstituteId));

        if (institute?.Id is null)
        {
            return Errors.Institute.NotFound;
        }

        return new SearchInstituteResult(institute);
    }
}