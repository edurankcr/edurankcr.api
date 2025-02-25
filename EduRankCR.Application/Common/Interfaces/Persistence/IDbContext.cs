using System.Data;

namespace EduRankCR.Application.Common.Interfaces.Persistence;

public interface IDbContext
{
    IDbConnection CreateConnection();
}