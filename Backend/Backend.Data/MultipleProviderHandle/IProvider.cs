using Microsoft.EntityFrameworkCore;

namespace Backend.Data.MultipleProviderHandle
{
    public interface IProvider
    {
        void OnConfiguring(DbContextOptionsBuilder options);
    }
}
