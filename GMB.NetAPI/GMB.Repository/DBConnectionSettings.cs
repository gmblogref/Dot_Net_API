using Insight.Database;
using System.Configuration;
using System.Linq;

namespace GMB.Repository
{
    public static class DBConnectionSettings
    {
        static ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;

        static DBConnectionSettings()
        {
            SqlInsightDbProvider.RegisterProvider();
        }

        public static T GetConnectionAs<T>(string connectionName) where T : class
        {
            return settings[connectionName].As<T>();
        }

        public static T GetParallelConnectionAs<T>(string connectionName) where T : class
        {
            return settings[connectionName].AsParallel<T>();
        }
    }
}
