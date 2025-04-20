using System.Data;
using Dapper;

using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Domain.Institutions.Projections;
using EduRankCR.Domain.Teachers.Projections;

namespace EduRankCR.Infrastructure.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly IDbContext _dbContext;

    public ActivityRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<InstitutionRatingProjection>> GetLatestInstitutionReviews()
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_InstitutionRating_GetLatest";

        var result = await connection.QueryAsync<InstitutionRatingProjection>(
            procedure,
            commandType: CommandType.StoredProcedure);

        return result.ToList();
    }

    public async Task<List<TeacherRatingProjection>> GetLatestTeacherReviews()
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_TeacherRating_GetLatest";

        var result = await connection.QueryAsync<TeacherRatingProjection>(
            procedure,
            commandType: CommandType.StoredProcedure);

        return result.ToList();
    }
}