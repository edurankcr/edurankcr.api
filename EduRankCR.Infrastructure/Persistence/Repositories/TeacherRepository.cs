using System.Data;
using Dapper;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.TeacherAggregate.Entities;

namespace EduRankCR.Infrastructure.Persistence.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly IDbContext _connectionFactory;

    public TeacherRepository(IDbContext connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task Create(Teacher teacher)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", teacher.UserId.Value);
        parameters.Add("@InstituteId", teacher.InstituteId.Value);
        parameters.Add("@Name", teacher.Name);
        parameters.Add("@LastName", teacher.LastName);
        parameters.Add("@Status", teacher.Status);

        await connection.QueryAsync("sp_Teacher__Create", parameters, commandType: CommandType.StoredProcedure);
    }
}