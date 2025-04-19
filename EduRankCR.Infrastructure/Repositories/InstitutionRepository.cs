using System.Data;

using Dapper;

using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Domain.Institutions.Projections;

namespace EduRankCR.Infrastructure.Repositories;

public class InstitutionRepository : IInstitutionRepository
{
    private readonly IDbContext _dbContext;

    public InstitutionRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<InstitutionProjection?> GetById(Guid institutionId)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_Institution_GetById";

        return await connection.QueryFirstOrDefaultAsync<InstitutionProjection>(
            procedure,
            new { InstitutionId = institutionId },
            commandType: CommandType.StoredProcedure);
    }
}