using System.Data;
using Dapper;

using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.InstituteAggregate.Entities;
using EduRankCR.Domain.InstituteAggregate.ValueObjects;
using EduRankCR.Domain.UserAggregate.ValueObjects;

namespace EduRankCR.Infrastructure.Persistence.Repositories;

public class InstituteRepository : IInstituteRepository
{
    private readonly IDbContext _connectionFactory;

    public InstituteRepository(IDbContext connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<Institute?> Find(InstituteId instituteId)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();

        parameters.Add("@InstituteId", instituteId.Value);

        var instituteDto = await connection.QueryFirstOrDefaultAsync(
            "sp_Institute__Find_Id",
            parameters,
            commandType: CommandType.StoredProcedure);

        if (instituteDto is null)
        {
            return null;
        }

        return Institute.CreateFromPersistence(
            instituteDto.InstituteId,
            instituteDto.UserId,
            instituteDto.Name,
            instituteDto.Type,
            instituteDto.Province,
            instituteDto.Url,
            instituteDto.Status);
    }

    public async Task<Institute?> FindLastByUserId(UserId userId)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId.Value);

        var instituteDto = await connection.QueryFirstOrDefaultAsync(
            "sp_Institute__Find_Last_UserId",
            parameters,
            commandType: CommandType.StoredProcedure);

        if (instituteDto is null)
        {
            return null;
        }

        return Institute.CreateFromPersistence(
            instituteDto.InstituteId,
            instituteDto.UserId,
            instituteDto.Name,
            instituteDto.Type,
            instituteDto.Province,
            instituteDto.Url,
            instituteDto.Status);
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
        parameters.Add("@Url", institute.Url);
        parameters.Add("@Status", institute.Status);

        await connection.QueryAsync("sp_Institute__Create", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<InstituteReview?> FindReviewByInstitute(UserId userId, InstituteId instituteId)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId.Value);
        parameters.Add("@InstituteId", instituteId.Value);

        var dto = await connection.QueryFirstOrDefaultAsync(
            "sp_InstituteReview__Find_InstituteId",
            parameters,
            commandType: CommandType.StoredProcedure);

        if (dto is null)
        {
            return null;
        }

        return InstituteReview.CreateFromPersistence(
            dto.ReviewId,
            dto.UserId,
            dto.InstituteId,
            dto.Reputation,
            dto.Opportunities,
            dto.Happiness,
            dto.Location,
            dto.Facilities,
            dto.Social,
            dto.Clubs,
            dto.Internet,
            dto.Security,
            dto.Food,
            dto.ExperienceText,
            dto.Status,
            dto.CreatedAt,
            dto.UpdatedAt);
    }

    public async Task CreateReview(InstituteReview instituteReview, InstituteId instituteId, UserId userId)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId.Value);
        parameters.Add("@InstituteId", instituteId.Value);
        parameters.Add("@Reputation", instituteReview.Reputation);
        parameters.Add("@Opportunities", instituteReview.Opportunities);
        parameters.Add("@Happiness", instituteReview.Happiness);
        parameters.Add("@Location", instituteReview.Location);
        parameters.Add("@Facilities", instituteReview.Facilities);
        parameters.Add("@Social", instituteReview.Social);
        parameters.Add("@Clubs", instituteReview.Clubs);
        parameters.Add("@Internet", instituteReview.Internet);
        parameters.Add("@Security", instituteReview.Security);
        parameters.Add("@Food", instituteReview.Food);
        parameters.Add("@ExperienceText", instituteReview.ExperienceText);
        parameters.Add("@Status", instituteReview.Status);
        parameters.Add("@CreatedAt", instituteReview.CreatedAt);
        parameters.Add("@UpdatedAt", instituteReview.UpdatedAt);

        await connection.QueryAsync("sp_InstituteReview__Create", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateReview(
        ReviewId reviewId,
        decimal? Reputation,
        decimal? Opportunities,
        decimal? Happiness,
        decimal? Location,
        decimal? Facilities,
        decimal? Social,
        decimal? Clubs,
        decimal? Internet,
        decimal? Security,
        decimal? Food,
        string? ExperienceText)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@ReviewId", reviewId.Value);
        parameters.Add("@Reputation", Reputation);
        parameters.Add("@Opportunities", Opportunities);
        parameters.Add("@Happiness", Happiness);
        parameters.Add("@Location", Location);
        parameters.Add("@Facilities", Facilities);
        parameters.Add("@Social", Social);
        parameters.Add("@Clubs", Clubs);
        parameters.Add("@Internet", Internet);
        parameters.Add("@Security", Security);
        parameters.Add("@Food", Food);
        parameters.Add("@ExperienceText", ExperienceText);

        await connection.QueryAsync("sp_InstituteReview__Update", parameters, commandType: CommandType.StoredProcedure);
    }
}