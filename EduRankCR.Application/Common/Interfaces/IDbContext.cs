using System.Data;

namespace EduRankCR.Application.Common.Interfaces;

public interface IDbContext
{
    IDbConnection CreateConnection();
}