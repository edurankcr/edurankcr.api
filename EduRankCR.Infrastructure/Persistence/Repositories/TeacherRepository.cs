﻿using System.Data;
using Dapper;
using EduRankCR.Domain.Common.Interfaces.Persistence;
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
        parameters.Add("@InstituteId", teacher.InstituteId.Value);
        parameters.Add("@Name", teacher.Name);
        parameters.Add("@LastName", teacher.LastName);
        parameters.Add("@Status", teacher.Status);

        await connection.QueryAsync("sp_Teacher__Create", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<Teacher?> FindById(TeacherId tokenId)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();

        parameters.Add("@TeacherId", tokenId.Value, DbType.Guid);

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
            dto.InstituteId,
            dto.Name,
            dto.LastName,
            dto.Status,
            dto.CreatedAt,
            dto.UpdatedAt);
    }

    public async Task CreateReview(TeacherReview teacherReview, Teacher teacher, UserId userId)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId.Value);
        parameters.Add("@TeacherId", teacher.Id.Value);
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

        await connection.QueryAsync("sp_TeacherReview__Create", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<TeacherReview?> IsReviewed(UserId userId, TeacherId teacherId)
    {
        using IDbConnection connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId.Value);
        parameters.Add("@TeacherId", teacherId.Value);

        var dto = await connection.QueryFirstOrDefaultAsync(
            "sp_TeacherReview__Find_Id_TeacherId",
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