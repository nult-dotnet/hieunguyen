using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Backend.Data.EF;
using Backend.Repository.UnitOfWork;
using MongoDB.Driver;
using ServiceStack;
using MongoDB.Driver.Linq;

namespace Backend.Repository.Generic
{
    public abstract class GenericRepositoryMongo<T> : IGenericRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _dbSet;

        protected GenericRepositoryMongo(IUnitOfWork unitOfWork)
        {
            IMongoDbContext context = (MongoDbContext)unitOfWork.Context;
            _dbSet = context.GetCollection<T>(typeof(T).Name);
        }

        public async Task<List<T>> FindAllAsync()
        {
            var all = await _dbSet.FindAsync(Builders<T>.Filter.Empty);

            return await all.ToListAsync();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            var data = await _dbSet.FindAsync(Builders<T>.Filter.Eq("ModelId", id));
            return await data.SingleOrDefaultAsync();
        }

        public async Task CreateAsync(T entity)
        {
            var modelType = typeof(T).Name;

            if (modelType != "UserRole")
            {
                var all = await _dbSet.FindAsync(Builders<T>.Filter.Empty);
                var allModels = await all.ToListAsync();
                var model = allModels.LastOrDefault();

                var id = model?.GetType().GetProperty("ModelId")?.GetValue(model, null)?.ToString();

                if (id != null) 
                    entity.GetType().GetProperty("ModelId")?.SetValue(entity, int.Parse(id) + 1, null);
                else
                {
                    entity.GetType().GetProperty("ModelId")?.SetValue(entity, 1, null);
                }
            }

            await _dbSet.InsertOneAsync(entity);
        }

        public void Update(T entity)
        {
            var id = entity.GetType().GetProperty("ModelId")?.GetValue(entity, null)?.ToString();
            _dbSet.ReplaceOneAsync(Builders<T>.Filter.Eq("ModelId", id), entity);
        }

        public void Delete(T entity)
        {
            _dbSet.DeleteOneAsync(Builders<T>.Filter.Eq("ModelId", entity.GetId()));
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            var result = _dbSet.Find(expression);

            return result.ToList();
        }
    }
}
