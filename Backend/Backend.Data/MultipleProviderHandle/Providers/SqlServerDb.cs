using Microsoft.EntityFrameworkCore;

namespace Backend.Data.MultipleProviderHandle.Providers
{
    public class SqlServerDb : IProvider
    {
        public void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(DbStringSettings.GetConnectionString(),
                x=>x.MigrationsAssembly("Backend.SqlServerMigrations"));
        }
    }
}
