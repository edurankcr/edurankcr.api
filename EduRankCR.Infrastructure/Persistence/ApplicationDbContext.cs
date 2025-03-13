using System.Data;
using EduRankCR.Domain.Common.Interfaces.Persistence;
using EduRankCR.Infrastructure.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace EduRankCR.Infrastructure.Persistence;

public class ApplicationDbContext : IDbContext
{
    private readonly string? _connectionString;

    public ApplicationDbContext(IOptions<DbSettings> dbSettings)
    {
        DbSettings dbSettingsValue = dbSettings.Value;
        _connectionString = Environment.GetEnvironmentVariable("env-databaseconnection") ?? dbSettingsValue.ConnectionString;
    }

    public IDbConnection CreateConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection;
    }
}