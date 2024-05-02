using BancoApp.Infrastructure.Interfaces.Repository;
using BancoApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _dbContext;
        private bool _disposed;
        private IDbContextTransaction? _trasaction;

        public UnitOfWork(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BeginTransaction()
        {
            _trasaction = _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
            _trasaction?.Commit();
        }

        public void Rollback()
        {
            _trasaction?.Rollback();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            return new Repository<T>(_dbContext);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Roolback()
        {
            throw new NotImplementedException();
        }
    }
}
