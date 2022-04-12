using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Backend.Data.EF;
using Backend.Repository.UnitOfWork;
using MongoDB.Driver;
using ServiceStack;

namespace Backend.Repository.Generic
{
    public abstract class GenericRepositoryMongo<T> : IGenericRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _dbSet;

        protected GenericRepositoryMongo(IUnitOfWork unitOfWork)
        {
            IMongoDbContext context = (MongoDbContext) unitOfWork.Context;
            _dbSet = context.GetCollection<T>(typeof(T).Name);
        }

        public async Task<List<T>> FindAllAsync()
        {
            var all = await _dbSet.FindAsync(Builders<T>.Filter.Empty);

            return await all.ToListAsync();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            var data = await _dbSet.FindAsync(Builders<T>.Filter.Eq("_id", id));
            return await data.SingleOrDefaultAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.InsertOneAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", entity.GetId()), entity);
        }

        public void Delete(T entity)
        {
            _dbSet.DeleteOneAsync(Builders<T>.Filter.Eq("_id", entity.GetId()));
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
           return (IQueryable<T>) _dbSet.Find(expression).ToEnumerable();
        }
    }
}
