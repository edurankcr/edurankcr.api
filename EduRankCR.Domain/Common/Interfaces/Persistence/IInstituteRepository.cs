using EduRankCR.Domain.InstituteAggregate.Entities;
using EduRankCR.Domain.InstituteAggregate.ValueObjects;

namespace EduRankCR.Domain.Common.Interfaces.Persistence;

public interface IInstituteRepository
{
    Task Create(Institute institute);
    Task<Institute?> Find(InstituteId instituteId);
}