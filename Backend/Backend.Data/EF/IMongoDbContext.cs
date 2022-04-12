using System;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Backend.Data.EF
{
    public interface IMongoDbContext : IDisposable
    {
        Task<int> SaveChangeAsync();
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
