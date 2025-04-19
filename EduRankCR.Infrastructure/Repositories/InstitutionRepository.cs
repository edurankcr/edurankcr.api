using System.Data;

using Dapper;

using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Domain.Institutions;
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

    public async Task<List<InstitutionRelatedProjection>> GetRelatedByProvince(Guid institutionId)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_Institution_GetRelatedByProvince";

        var result = await connection.QueryAsync<InstitutionRelatedProjection>(
            procedure,
            new { InstitutionId = institutionId },
            commandType: CommandType.StoredProcedure);

        return result.ToList();
    }

    public async Task Create(Institution institution)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_Institution_Create";

        var parameters = new
        {
            institution.InstitutionId,
            institution.UserId,
            institution.Name,
            institution.Description,
            Province = (byte)institution.Province,
            Type = (byte)institution.Type,
            institution.WebsiteUrl,
            institution.AiReviewSummary,
            Status = (byte)institution.Status,
        };

        await connection.ExecuteAsync(
            procedure,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> ExistsInReview(Guid userId)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_Institution_ExistsInReview";

        return await connection.ExecuteScalarAsync<bool>(
            procedure,
            new { UserId = userId },
            commandType: CommandType.StoredProcedure);
    }
}