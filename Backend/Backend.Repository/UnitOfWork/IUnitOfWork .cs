using System.Threading.Tasks;

namespace Backend.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        void CreateTransaction();
        void Commit();
        void Rollback();
        object Context { get; }
    }
}
