using EduRankCR.Domain.InstituteAggregate.Entities;

namespace EduRankCR.Application.Common.Interfaces.Persistence;

public interface IInstituteRepository
{
    Task Create(Institute institute);
}