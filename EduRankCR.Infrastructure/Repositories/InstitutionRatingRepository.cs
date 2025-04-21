using System.Data;

using Dapper;
using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Domain.Institutions;
using EduRankCR.Domain.Institutions.Projections;

namespace EduRankCR.Infrastructure.Repositories;

public class InstitutionRatingRepository : IInstitutionRatingRepository
{
    private readonly IDbContext _dbContext;

    public InstitutionRatingRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<InstitutionRatingProjection>?> GetByInstitutionId(Guid institutionId)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_InstitutionRating_GetByInstitutionId";

        return await connection.QueryAsync<InstitutionRatingProjection>(
            procedure,
            new { InstitutionId = institutionId },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<InstitutionRatingProjection?> GetByInstitutionAndUser(Guid institutionId, Guid userId)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_InstitutionRating_GetByInstitutionIdAndUserId";

        return await connection.QueryFirstOrDefaultAsync<InstitutionRatingProjection>(
            procedure,
            new { InstitutionId = institutionId, UserId = userId },
            commandType: CommandType.StoredProcedure);
    }

    public async Task CreateRating(InstitutionRating rating)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_InstitutionRating_Create";

        var parameters = new DynamicParameters();
        parameters.Add("InstitutionId", rating.InstitutionId);
        parameters.Add("UserId", rating.UserId);
        parameters.Add("Location", rating.Location);
        parameters.Add("Happiness", rating.Happiness);
        parameters.Add("Safety", rating.Safety);
        parameters.Add("Reputation", rating.Reputation);
        parameters.Add("Opportunities", rating.Opportunities);
        parameters.Add("Internet", rating.Internet);
        parameters.Add("Food", rating.Food);
        parameters.Add("Social", rating.Social);
        parameters.Add("Facilities", rating.Facilities);
        parameters.Add("Clubs", rating.Clubs);
        parameters.Add("Testimony", rating.Testimony);
        parameters.Add("CreatedAt", rating.CreatedAt);
        parameters.Add("Status", rating.Status);

        await connection.ExecuteAsync(
            procedure,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> HasUserAlreadyRated(Guid institutionId, Guid userId)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_InstitutionRating_ExistsByUser";

        var parameters = new DynamicParameters();
        parameters.Add("InstitutionId", institutionId);
        parameters.Add("UserId", userId);

        var result = await connection.ExecuteScalarAsync<int>(
            procedure,
            parameters,
            commandType: CommandType.StoredProcedure);

        return result == 1;
    }

    public async Task Update(
        Guid institutionRatingId,
        Guid userId,
        int? location,
        int? happiness,
        int? safety,
        int? reputation,
        int? opportunities,
        int? internet,
        int? food,
        int? social,
        int? facilities,
        int? clubs,
        string? testimony)
    {
        using var connection = _dbContext.CreateConnection();

        const string procedure = "usp_InstitutionRating_Update";

        var parameters = new DynamicParameters();
        parameters.Add("@InstitutionRatingId", institutionRatingId);
        parameters.Add("@UserId", userId);
        parameters.Add("@Location", location);
        parameters.Add("@Happiness", happiness);
        parameters.Add("@Safety", safety);
        parameters.Add("@Reputation", reputation);
        parameters.Add("@Opportunities", opportunities);
        parameters.Add("@Internet", internet);
        parameters.Add("@Food", food);
        parameters.Add("@Social", social);
        parameters.Add("@Facilities", facilities);
        parameters.Add("@Clubs", clubs);
        parameters.Add("@Testimony", testimony);

        await connection.ExecuteAsync(
            procedure,
            parameters,
            commandType: CommandType.StoredProcedure);
    }
}