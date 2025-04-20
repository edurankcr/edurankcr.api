using System.Data;

using Dapper;
using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Domain.Search.Projections;

namespace EduRankCR.Infrastructure.Repositories;

public class SearchRepository : ISearchRepository
{
    private readonly IDbContext _dbContext;

    public SearchRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<(SearchMetaProjection Meta, List<SearchResultProjection> Results)> SearchByName(string name)
    {
        using var connection = _dbContext.CreateConnection();

        const string sp = "usp_Search_ByName";

        await using var multi = await connection.QueryMultipleAsync(
            sp,
            new { Name = name },
            commandType: CommandType.StoredProcedure);

        var meta = await multi.ReadSingleAsync<SearchMetaProjection>();
        var results = (await multi.ReadAsync<SearchResultProjection>()).ToList();

        return (meta, results);
    }
}