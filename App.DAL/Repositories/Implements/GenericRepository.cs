using App.DAL.Extentions;
using App.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext DbContext;
        private readonly DbSet<T> _entitySet;
        public GenericRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
            _entitySet = DbContext.Set<T>();
        }

        public void Add(T entity, Guid? userId = null)
        {
            entity.TrySetProperty("CreatedDate", DateTime.Now);
            entity.TrySetProperty("LastUpdatedDate", DateTime.Now);
            if (userId != null)
            {
                entity.TrySetProperty("CreatedBy", userId);
                entity.TrySetProperty("LastUpdatedBy", userId);
            }
            DbContext.Add(entity);
        }

        public async Task AddAsync(T entity, Guid? userId = null, CancellationToken cancellationToken = default)
        {
            entity.TrySetProperty("CreatedDate", DateTime.Now);
            entity.TrySetProperty("LastUpdatedDate", DateTime.Now);
            if (userId != null)
            {
                entity.TrySetProperty("CreatedBy", userId);
                entity.TrySetProperty("LastUpdatedBy", userId);
            }
            await DbContext.AddAsync(entity, cancellationToken);
        }

        public void AddRange(IEnumerable<T> entities, Guid? userId = null)
        {
            var enumerable = entities.ToList();
            enumerable.ForEach(entity =>
            {
                entity.TrySetProperty("CreatedDate", DateTime.Now);
                entity.TrySetProperty("LastUpdatedDate", DateTime.Now);
                if (userId != null)
                {
                    entity.TrySetProperty("CreatedBy", userId);
                    entity.TrySetProperty("LastUpdatedBy", userId);
                }
            });

            DbContext.AddRange(enumerable);
        }
        public void AddRangeCompact(IEnumerable<T> entities)
        {
            var enumerable = entities.ToList();

            DbContext.AddRange(enumerable);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
            => await DbContext.AddRangeAsync(entities, cancellationToken);



        public IQueryable<T> Queryable() => _entitySet.AsQueryable().WhereExistsOrAll("IsDeleted", false);

        public IQueryable<T> QueryableAll() => _entitySet.AsQueryable();

        public IQueryable<T> WithLocalizationNoTracking() => _entitySet.WhereExistsOrAll("","").WhereExistsOrAll("IsDeleted", false);
        public IQueryable<T> WithLocalizationNoTrackingAll() => _entitySet.WhereExistsOrAll("","").AsNoTracking();

        // Get all data with IsDelete = false or not exist IsDelete column
        public IQueryable<T> AsNoTracking() => _entitySet.AsNoTracking().WhereExistsOrAll("IsDeleted", false);

        // Get all data
        public IQueryable<T> AsNoTrackingAll() => _entitySet.AsNoTracking();

        public bool SoftDelete(T entity, Guid? userId)
        {
            entity.TrySetProperty("LastUpdatedDate", DateTime.Now);
            entity.TrySetProperty("IsDeleted", true);

            if (userId != null)
            {
                entity.TrySetProperty("DeletedBy", userId);
                entity.TrySetProperty("DeletedDate", DateTime.Now);
            }
            _entitySet.Update(entity);
            return true;
        }

        public T? Get(Expression<Func<T, bool>> expression)
            => _entitySet.FirstOrDefault(expression);

        public IEnumerable<T> GetAll()
            => _entitySet.AsEnumerable();

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
            => _entitySet.Where(expression).AsEnumerable();

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _entitySet.ToListAsync(cancellationToken);

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
            => await _entitySet.Where(expression).ToListAsync(cancellationToken);

        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
            => await _entitySet.FirstOrDefaultAsync(expression, cancellationToken);

        public void Remove(T entity)
            => DbContext.Remove(entity);

        public void RemoveRange(IEnumerable<T> entities)
            => DbContext.RemoveRange(entities);

        public void Update(T entity, Guid? userId = null)
        {
            if (userId != null)
            {
                entity.TrySetProperty("LastUpdatedBy", userId);
                entity.TrySetProperty("LastUpdatedDate", DateTime.Now);
            }
            DbContext.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
            => DbContext.UpdateRange(entities);

        public int SaveChange()
        {
            return DbContext.SaveChanges();
        }

        public async Task<int> SaveChangeAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
    }

}
