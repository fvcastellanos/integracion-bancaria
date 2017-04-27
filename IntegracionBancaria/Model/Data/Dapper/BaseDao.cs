
namespace IntegracionBancaria.Model.Data.Dapper
{
    public abstract class BaseDao
        {
            protected static string LastInsertId = "select LAST_INSERT_ID()";

            protected AppSettings Settings { get; }

            protected ILogger Logger; 
            protected BaseDao(IOptions<AppSettings> appSettings, ILogger logger)
            {
                Settings = appSettings.Value;
                Logger = logger;
            }
            
            protected IDbConnection GetConnection()
            {
                Logger.LogInformation("Getting DB connection");
                return new MySqlConnection(Settings.ConnectionString);
            }

            protected long GetLasInsertedId() {
                Logger.LogInformation("Getting last inserted Id");
                return GetConnection().Query<long>(LastInsertId).Single();
            }
    }
}