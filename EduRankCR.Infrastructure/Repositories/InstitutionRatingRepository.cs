using System.Data;

using Dapper;
using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Application.Institutions.Common;
using EduRankCR.Domain.Institutions.Projections;

namespace EduRankCR.Infrastructure.Repositories;

public class InstitutionRatingRepository : IInstitutionRatingRepository
{
    private readonly IDbContext _dbContext;

    public InstitutionRatingRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<InstitutionRatingProjection>?> GetByInstitutionId(Guid institutionId)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_InstitutionRating_GetByInstitutionId";

        return await connection.QueryAsync<InstitutionRatingProjection>(
            procedure,
            new { InstitutionId = institutionId },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<List<LatestInstitutionRatingProjection>> GetLatestRatings()
    {
        using var connection = _dbContext.CreateConnection();

        const string sp = "usp_InstitutionRating_GetLatest";

        var result = await connection.QueryAsync<LatestInstitutionRatingProjection>(
            sp,
            commandType: CommandType.StoredProcedure);

        return result.ToList();
    }
}