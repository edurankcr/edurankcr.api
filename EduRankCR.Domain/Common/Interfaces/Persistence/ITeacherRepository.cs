using EduRankCR.Domain.TeacherAggregate.Entities;

namespace EduRankCR.Domain.Common.Interfaces.Persistence;

public interface ITeacherRepository
{
    Task Create(Teacher teacher);
}