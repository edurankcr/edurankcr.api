using EduRankCR.Application.Commands.Search.Common;
using EduRankCR.Domain.Common.Interfaces.Persistence;

using ErrorOr;

using MediatR;

namespace EduRankCR.Application.Commands.Search.Queries;

public class SearchQueryHandler : IRequestHandler<SearchQuery, ErrorOr<SearchResult>>
{
    private readonly ISearchRepository _searchRepository;

    public SearchQueryHandler(
        ISearchRepository searchRepository)
    {
        _searchRepository = searchRepository;
    }

    public async Task<ErrorOr<SearchResult>> Handle(SearchQuery query, CancellationToken cancellationToken)
    {
        var (teachers, institutes) = await _searchRepository.SearchAll(
            query.Name,
            query.Type,
            query.InstituteId,
            query.TypeFilter,
            query.Province,
            query.District);
        return new SearchResult(teachers, institutes);
    }
}