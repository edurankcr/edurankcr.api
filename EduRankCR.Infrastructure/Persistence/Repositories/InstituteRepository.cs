using System.Data;
using Dapper;
using EduRankCR.Application.Common.Interfaces.Persistence;
using EduRankCR.Domain.InstituteAggregate.Entities;

namespace EduRankCR.Infrastructure.Persistence.Repositories;

public class InstituteRepository : IInstituteRepository
{
    private readonly IDbContext _connectionFactory;

    public InstituteRepository(IDbContext connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task Create(Institute institute)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@InstituteId", institute.Id.Value, DbType.Guid);
        parameters.Add("@UserId", institute.UserId.Value, DbType.Guid);
        parameters.Add("@Status", institute.Status, DbType.String);

        await connection.QueryAsync("sp_Token__Create", parameters, commandType: CommandType.StoredProcedure);
    }
}