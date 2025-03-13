using System.Data;

namespace EduRankCR.Domain.Common.Interfaces.Persistence;

public interface IDbContext
{
    IDbConnection CreateConnection();
}