using System;
using Backend.Data.EF;
using Backend.Data.MultipleProviderHandle;

namespace Backend.Repository.UnitOfWork
{
    public static class InstanceUnitOfWork
    {
        public static IUnitOfWork UnitOfWork()
        {
            var mongoContext = new MongoDbContext();
            var context = new BackendDbContext();
            string databaseDefault = DbStringSettings.GetDefaultDbValue();
            try
            {
                if (databaseDefault.Equals("MongoDb"))
                {
                    return new UnitOfWorkMongo(mongoContext);
                }
                return new UnitOfWork(context);
            }
            catch
            {
                throw new NotImplementedException("Database deafault not a valid database type");
            }
        }
    }
}
