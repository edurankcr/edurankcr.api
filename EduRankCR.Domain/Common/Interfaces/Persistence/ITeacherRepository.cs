using EduRankCR.Domain.TeacherAggregate.Entities;
using EduRankCR.Domain.TeacherAggregate.ValueObjects;
using EduRankCR.Domain.UserAggregate.ValueObjects;

namespace EduRankCR.Domain.Common.Interfaces.Persistence;

public interface ITeacherRepository
{
    Task Create(Teacher teacher);
    Task CreateReview(TeacherReview teacherReview, Teacher teacher, UserId userId);
    Task<TeacherReview?> IsReviewed(UserId userId, TeacherId teacherId);
    Task<Teacher?> FindById(TeacherId userId);
}