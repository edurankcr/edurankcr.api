using EduRankCR.Domain.Search.Projections;

namespace EduRankCR.Application.Common.Interfaces;

public interface ISearchRepository
{
    Task<(SearchMetaProjection Meta, List<SearchResultProjection> Results)> SearchByName(string name);
}