using EduRankCR.Domain.TeacherAggregate.Entities;

namespace EduRankCR.Application.Common.Interfaces.Persistence;

public interface ITeacherRepository
{
    Task Create(Teacher teacher);
}