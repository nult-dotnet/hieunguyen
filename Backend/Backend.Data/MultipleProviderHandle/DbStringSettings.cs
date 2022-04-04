using Microsoft.Extensions.Configuration;

namespace Backend.Data.MultipleProviderHandle
{
    public static class DbStringSettings
    {
        public static string GetConnectionString()
        {
            var defaultDb = GetDefaultDbValue();
            var connectionString = GetConfiguration().GetConnectionString(defaultDb);
            return connectionString;
        }

        public static string GetDefaultDbValue()
        {
            var defaultDb = GetConfiguration().GetValue<string>("DefaultDb");
            return defaultDb;
        }

        private static IConfiguration GetConfiguration()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration;
        }
    }
}
