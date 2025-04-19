using EduRankCR.Application.Institutions.Common;

namespace EduRankCR.Application.Common.Interfaces;

public interface IInstitutionRepository
{
    Task<InstitutionBasicInfoResult?> GetById(Guid id);
}