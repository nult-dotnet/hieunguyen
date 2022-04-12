using System;
using Backend.Data.MultipleProviderHandle;
using Backend.Repository.UnitOfWork;

namespace Backend.Repository.Generic
{
    public static class InstanceGenericRepository<T> where T : class
    {
        public static IGenericRepository<T> Repository(IUnitOfWork unitOfWork)
        {
            string databaseDefault = DbStringSettings.GetDefaultDbValue();
            try
            {
                if (databaseDefault.Equals("MongoDB"))
                {
                    return new UnitOfWorkMongo.Repository<T>(unitOfWork);
                }
                return new UnitOfWork.UnitOfWork.Repository<T>(unitOfWork);
            }
            catch(Exception ex)
            {
                throw new NotImplementedException("Database deafault not a valid database type");
            }
        }
    }
}
