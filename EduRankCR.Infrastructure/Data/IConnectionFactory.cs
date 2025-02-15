using System.Data;

namespace EduRankCR.Infrastructure.Data
{
    public interface IConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}