using System.Data;
using Dapper;
using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Domain.Institutions.Projections;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EduRankCR.Infrastructure.Repositories;

public class InstitutionRatingAggregateRepository : IInstitutionRatingAggregateRepository
{
    private readonly IDbContext _dbContext;

    public InstitutionRatingAggregateRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<InstitutionRatingAggregateProjection?> GetByInstitutionId(Guid institutionId)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_InstitutionRatingAggregate_GetByInstitutionId";

        return await connection.QueryFirstOrDefaultAsync<InstitutionRatingAggregateProjection>(
            procedure,
            new { InstitutionId = institutionId },
            commandType: CommandType.StoredProcedure);
    }
}