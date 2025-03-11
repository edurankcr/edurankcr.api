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
        parameters.Add("@UserId", institute.UserId.Value);
        parameters.Add("@InstituteId", institute.Id.Value);
        parameters.Add("@Name", institute.Name);
        parameters.Add("@Type", institute.Type);
        parameters.Add("@Province", institute.Province);
        parameters.Add("@District", institute.District);
        parameters.Add("@Url", institute.Url);
        parameters.Add("@Status", institute.Status);

        await connection.QueryAsync("sp_Institute_Create", parameters, commandType: CommandType.StoredProcedure);
    }
}