using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Application.Search.Common;
using ErrorOr;
using MediatR;

namespace EduRankCR.Application.Search.Queries.SearchByName;

public sealed class SearchByNameQueryHandler : IRequestHandler<SearchByNameQuery, ErrorOr<SearchResult>>
{
    private readonly ISearchRepository _repository;

    public SearchByNameQueryHandler(ISearchRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<SearchResult>> Handle(SearchByNameQuery request, CancellationToken cancellationToken)
    {
        var (metaProjection, resultProjections) = await _repository.SearchByName(request.Name);

        var institutions = resultProjections
            .Where(r => r.Type == "Institution")
            .Select(r => new SearchInstitutionItem(
                r.Id,
                r.Name,
                r.Province!.Value,
                r.InstitutionType!.Value,
                r.CreatedAt,
                r.UpdatedAt,
                r.OverallAverage,
                r.ReviewCount))
            .ToList();

        var teachers = resultProjections
            .Where(r => r.Type == "Teacher")
            .Select(r => new SearchTeacherItem(
                r.Id,
                r.Name,
                r.LastName!,
                r.CreatedAt,
                r.UpdatedAt,
                r.OverallAverage,
                r.ReviewCount))
            .ToList();

        return new SearchResult(
            new SearchMeta(
                metaProjection.AllCount,
                metaProjection.AllInstitutionCount,
                metaProjection.AllTeacherCount),
            institutions,
            teachers);
    }
}