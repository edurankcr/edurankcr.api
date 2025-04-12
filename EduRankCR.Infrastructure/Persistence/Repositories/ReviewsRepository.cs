using System.Data;
using Dapper;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.Common.Projections;

namespace EduRankCR.Infrastructure.Persistence.Repositories;

public class ReviewsRepository : IReviewsRepository
{
    private readonly IDbContext _connectionFactory;

    public ReviewsRepository(IDbContext connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<(List<ReviewTeacherProjection> TeacherReviews, List<ReviewInstituteProjection> InstituteReviews)> GetLastReviews()
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        await using var multi = await connection.QueryMultipleAsync("sp_Reviews__Get_All", commandType: CommandType.StoredProcedure);

        var teacherReviews = (await multi.ReadAsync<ReviewTeacherProjection>()).ToList();
        var instituteReviews = (await multi.ReadAsync<ReviewInstituteProjection>()).ToList();

        return (teacherReviews, instituteReviews);
    }
}