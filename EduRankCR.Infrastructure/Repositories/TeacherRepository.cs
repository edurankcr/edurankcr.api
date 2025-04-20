using System.Data;

using Dapper;

using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Domain.Teachers;
using EduRankCR.Domain.Teachers.Projections;

namespace EduRankCR.Infrastructure.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly IDbContext _dbContext;

    public TeacherRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(Teacher teacher)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_Teacher_Create";

        var parameters = new
        {
            teacher.TeacherId,
            teacher.UserId,
            teacher.Name,
            teacher.LastName,
            teacher.Biography,
            teacher.AvatarUrl,
            teacher.CreatedAt,
            teacher.UpdatedAt,
            teacher.Status,
        };

        await connection.ExecuteAsync(
            procedure,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task<TeacherProjection?> GetById(Guid teacherId)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_Teacher_GetById";

        return await connection.QueryFirstOrDefaultAsync<TeacherProjection>(
            procedure,
            new { TeacherId = teacherId },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> ExistsPendingByUserId(Guid userId)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_Teacher_ExistsPendingByUserId";

        var result = await connection.QueryFirstOrDefaultAsync<int?>(
            procedure,
            new { UserId = userId },
            commandType: CommandType.StoredProcedure);

        return result.HasValue;
    }
}