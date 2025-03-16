using System.Data;
using Dapper;

using EduRankCR.Domain.Common.Enums;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Domain.InstituteAggregate.ValueObjects;
using EduRankCR.Domain.TeacherAggregate.Entities;
using EduRankCR.Domain.TeacherAggregate.ValueObjects;
using EduRankCR.Domain.UserAggregate.ValueObjects;

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
        parameters.Add("@Name", teacher.Name);
        parameters.Add("@LastName", teacher.LastName);
        parameters.Add("@Status", teacher.Status);

        await connection.QueryAsync("sp_Teacher__Create", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<Teacher?> FindById(TeacherId teacherId)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();

        parameters.Add("@TeacherId", teacherId.Value);

        var dto = await connection.QueryFirstOrDefaultAsync(
            "sp_Teacher__Find_Id",
            parameters,
            commandType: CommandType.StoredProcedure);

        if (dto is null)
        {
            return null;
        }

        return Teacher.CreateFromPersistence(
            dto.TeacherId,
            dto.UserId,
            dto.Name,
            dto.LastName,
            dto.Status,
            dto.CreatedAt,
            dto.UpdatedAt);
    }

    public async Task CreateReview(UserId userId, TeacherId teacherId, InstituteId instituteId, TeacherReview teacherReview)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId.Value);
        parameters.Add("@TeacherId", teacherId.Value);
        parameters.Add("@InstituteId", instituteId.Value);
        parameters.Add("@FreeCourse", teacherReview.FreeCourse);
        parameters.Add("@CourseCode", teacherReview.CourseCode);
        parameters.Add("@CourseMode", teacherReview.CourseMode);
        parameters.Add("@ProfessorRating", teacherReview.ProfessorRating);
        parameters.Add("@DifficultyRating", teacherReview.DifficultyRating);
        parameters.Add("@WouldTakeAgain", teacherReview.WouldTakeAgain);
        parameters.Add("@MandatoryAttendance", teacherReview.MandatoryAttendance);
        parameters.Add("@GradeReceived", teacherReview.GradeReceived);
        parameters.Add("@ExperienceText", teacherReview.ExperienceText);
        parameters.Add("@Status", teacherReview.Status);
        parameters.Add("@CreatedAt", teacherReview.CreatedAt);
        parameters.Add("@UpdatedAt", teacherReview.UpdatedAt);

        await connection.QueryAsync("sp_Teacher_Review__Create", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateReview(
        ReviewId reviewId,
        InstituteId? instituteId,
        bool? freeCourse,
        string? courseCode,
        int? courseMode,
        decimal? professorRating,
        decimal? difficultyRating,
        bool? wouldTakeAgain,
        bool? mandatoryAttendance,
        string? gradeReceived,
        string? experienceText)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@ReviewId", reviewId.Value);
        parameters.Add("@InstituteId", instituteId?.Value);
        parameters.Add("@FreeCourse", freeCourse);
        parameters.Add("@CourseCode", courseCode);
        parameters.Add("@CourseMode", courseMode);
        parameters.Add("@ProfessorRating", professorRating);
        parameters.Add("@DifficultyRating", difficultyRating);
        parameters.Add("@WouldTakeAgain", wouldTakeAgain);
        parameters.Add("@MandatoryAttendance", mandatoryAttendance);
        parameters.Add("@GradeReceived", gradeReceived);
        parameters.Add("@ExperienceText", experienceText);

        await connection.QueryAsync("sp_Teacher_Review__Update", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<TeacherReview?> FindReviewByTeacher(UserId userId, TeacherId teacherId)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId.Value);
        parameters.Add("@TeacherId", teacherId.Value);

        var dto = await connection.QueryFirstOrDefaultAsync(
            "sp_Teacher_Review__Find_TeacherId",
            parameters,
            commandType: CommandType.StoredProcedure);

        if (dto is null)
        {
            return null;
        }

        return TeacherReview.CreateFromPersistence(
            dto.ReviewId,
            dto.UserId,
            dto.TeacherId,
            dto.InstituteId,
            dto.FreeCourse,
            dto.CourseCode,
            dto.CourseMode,
            dto.ProfessorRating,
            dto.DifficultyRating,
            dto.WouldTakeAgain,
            dto.MandatoryAttendance,
            dto.GradeReceived,
            dto.ExperienceText,
            dto.Status,
            dto.CreatedAt,
            dto.UpdatedAt);
    }
}