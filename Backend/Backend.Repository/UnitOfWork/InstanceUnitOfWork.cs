using System;
using Backend.Data.MultipleProviderHandle;

namespace Backend.Repository.UnitOfWork
{
    public static class InstanceUnitOfWork
    {
        public static IUnitOfWork UnitOfWork()
        {
            string databaseDefault = DbStringSettings.GetDefaultDbValue();
            try
            {
                if (databaseDefault.Equals("MongoDB"))
                {
                    return new UnitOfWorkMongo();
                }
                return new UnitOfWork();
            }
            catch
            {
                throw new NotImplementedException("Database deafault not a valid database type");
            }
        }
    }
}
