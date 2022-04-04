using Microsoft.EntityFrameworkCore;

namespace Backend.Data.MultipleProviderHandle.Providers
{
    public class PostgresDb : IProvider
    {
        public void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(DbStringSettings.GetConnectionString(), 
                x=>x.MigrationsAssembly("Backend.PostgresSqlMigrations"));
        }
    }
}
