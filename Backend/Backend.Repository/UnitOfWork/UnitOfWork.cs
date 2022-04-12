using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Data.EF;
using Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore.Storage;

namespace Backend.Repository.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly BackendDbContext _context;
        private IDbContextTransaction _objTran;
        private Dictionary<string, object> _repositories;

        public UnitOfWork()
        {
            _context = new BackendDbContext();
        }

        public object Context => _context;

        public void CreateTransaction()
        {
            _objTran = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _objTran.Commit();
        }

        public void Rollback()
        {
            _objTran.Rollback();
            _objTran.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }

        public class Repository<T> : GenericRepository<T> where T : class
        {
            public Repository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        }
    }
}
