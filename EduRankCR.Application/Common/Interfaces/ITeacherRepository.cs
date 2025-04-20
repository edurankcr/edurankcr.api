using EduRankCR.Domain.Teachers;
using EduRankCR.Domain.Teachers.Projections;

namespace EduRankCR.Application.Common.Interfaces;

public interface ITeacherRepository
{
    Task Create(Teacher teacher);
    Task<TeacherProjection?> GetById(Guid teacherId);
    Task<bool> ExistsPendingByUserId(Guid userId);
}