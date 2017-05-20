
using System.Data;
using System.Linq;
using Npgsql;
using Dapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IntegracionBancaria.Model.Data.Dapper
{
    public abstract class BaseDao
        {
            protected static string LastInsertId = "select LAST_INSERT_ID()";

            protected AppSettings Settings { get; }

            protected readonly ILogger _logger; 
            protected BaseDao(IOptions<AppSettings> appSettings, ILogger logger)
            {
                Settings = appSettings.Value;
                _logger = logger;
            }
            
            protected IDbConnection GetConnection()
            {
                _logger.LogInformation("Getting DB connection");
                return new NpgsqlConnection(Settings.ConnectionString);
            }

            protected long GetLasInsertedId() {
                _logger.LogInformation("Getting last inserted Id");
                return GetConnection().Query<long>(LastInsertId).Single();
            }

            protected long GetNexSequenceNumber(IDbConnection db, string sequenceName)
            {
                var nextSequenceSql = "select nextval(@SequenceName)";
                _logger.LogInformation("Getting next sequence value of: {0}", sequenceName);
                return db.Query<long>(nextSequenceSql, new { SequenceName = sequenceName }).Single();
            }
    }
}