using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Backend.Repository.Generic
{
    public interface IGenericRepository<T>
    {
        Task<List<T>> FindAllAsync();
        Task<T> FindByIdAsync(int Id);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
    }
}
