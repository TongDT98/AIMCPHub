using App.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BeginTransaction()
        {
            if (_dbContext.Database.CurrentTransaction != null)
            {
                return;
            }
            _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_dbContext.Database.CurrentTransaction == null)
            {
                return;
            }
            _dbContext.Database.CommitTransaction();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Rollback()
        {
            if (_dbContext.Database.CurrentTransaction == null)
            {
                return;
            }
            _dbContext.Database.RollbackTransaction();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
