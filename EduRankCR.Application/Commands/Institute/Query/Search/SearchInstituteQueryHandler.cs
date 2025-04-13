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
        var (institute, summary) = await _instituteRepository.Details(InstituteId.ConvertFromString(query.InstituteId));

        if (institute?.Id is null)
        {
            return Errors.Institute.NotFound;
        }

        if (summary?.Id is null)
        {
            return Errors.Institute.SummaryNotFound;
        }

        return new SearchInstituteResult(
            institute,
            summary);
    }
}