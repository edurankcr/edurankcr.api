using System.Data;

using Dapper;

using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Application.Institutions.Common;

namespace EduRankCR.Infrastructure.Repositories;

public class InstitutionRepository : IInstitutionRepository
{
    private readonly IDbContext _dbContext;

    public InstitutionRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<InstitutionBasicInfoResult?> GetById(Guid id)
    {
        using var connection = _dbContext.CreateConnection();

        const string sp = "usp_GetInstitutionById";

        return await connection.QuerySingleOrDefaultAsync<InstitutionBasicInfoResult>(
            sp,
            new { InstitutionId = id },
            commandType: CommandType.StoredProcedure);
    }
}