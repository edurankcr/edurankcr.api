using System.Data;
using Dapper;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.InstituteAggregate.Entities;
using EduRankCR.Domain.TeacherAggregate.Entities;

namespace EduRankCR.Infrastructure.Persistence.Repositories;

public class SearchRepository : ISearchRepository
{
    private readonly IDbContext _connectionFactory;

    public SearchRepository(IDbContext connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<(List<Teacher> Teachers, List<Institute> Institutes)> SearchAll(
        string name,
        string? type,
        string? instituteId,
        int? typeFilter,
        int? province,
        int? district)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@Name", name);
        parameters.Add("@Type", type);
        parameters.Add("@InstituteId", instituteId);
        parameters.Add("@TypeFilter", typeFilter);
        parameters.Add("@Province", province);
        parameters.Add("@District", district);

        await using var multi = await connection.QueryMultipleAsync("sp_Search__All", parameters, commandType: CommandType.StoredProcedure);

        var teachers = multi.Read<Teacher>().ToList();
        var institutes = multi.Read<Institute>().ToList();

        return (teachers, institutes);
    }
}