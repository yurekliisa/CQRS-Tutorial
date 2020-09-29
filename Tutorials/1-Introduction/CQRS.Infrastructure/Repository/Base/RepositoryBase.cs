using CQRS.Core.Entity;
using CQRS.Core.Repository;
using CQRS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Infrastructure.Repository.Base
{
    public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey>
       where TKey : IEquatable<TKey>
       where TEntity : class, IEntityBase<TKey>, new()
    {
        protected CQRSContext _dbContext;
        protected DbSet<TEntity> _dbSet;

        public RepositoryBase(
            CQRSContext dbContexT
            )
        {
            _dbContext = dbContexT ?? throw new ArgumentException("An instance of DbContext is required to use this repository.");
            _dbSet = _dbContext.Set<TEntity>();
        }

        #region Insert
        public virtual TEntity Insert(TEntity entity, bool autoSave = false)
        {
            TEntity savedEntity = _dbSet.Add(entity).Entity;

            if (autoSave)
            {
                _dbContext.SaveChanges();
            }

            return savedEntity;
        }
        public virtual async Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false)
        {
            TEntity savedEntity = _dbSet.Add(entity).Entity;

            if (autoSave)
            {
                await _dbContext.SaveChangesAsync();
            }

            return savedEntity;
        }
        #endregion

        #region Update
        public virtual TEntity Update(TEntity entity, bool autoSave = false)
        {
            _dbContext.Attach(entity);

            TEntity updatedEntity = _dbContext.Update(entity).Entity;

            if (autoSave)
            {
                _dbContext.SaveChanges();
            }

            return updatedEntity;
        }
        public virtual async Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false)
        {
            _dbContext.Attach(entity);

            TEntity updatedEntity = _dbContext.Update(entity).Entity;

            if (autoSave)
            {
                await _dbContext.SaveChangesAsync();
            }

            return updatedEntity;
        }
        #endregion

        #region Delete
        public virtual void Delete(TEntity entity, bool autoSave = false)
        {
            _dbSet.Remove(entity);

            if (autoSave)
            {
                _dbContext.SaveChanges();
            }
        }
        public virtual async Task DeleteAsync(TEntity entity, bool autoSave = false)
        {
            _dbSet.Remove(entity);

            if (autoSave)
            {
                await _dbContext.SaveChangesAsync();
            }
        }
        #endregion

        #region GetList with includeDetails
        public virtual List<TEntity> GetList(bool includeDetails = false)
        {
            return _dbSet.ToList();
        }
        public virtual async Task<List<TEntity>> GetListAsync(bool includeDetails = false)
        {
            return await _dbSet.ToListAsync();
        }

        #endregion

        #region GetQueryable
        public virtual IQueryable<TEntity> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }
        #endregion
      
        #region Get
        public virtual TEntity Get(TKey id)
        {
            TEntity entity = _dbSet.FirstOrDefault(x=>x.Id.Equals(id));
            if (entity == null)
            {
                //throw new EntityNotFoundException(typeof(TEntity), id);
            }
            return entity;
        }

        public virtual async Task<TEntity> GetAsync(TKey id)
        {
            TEntity entity = await _dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (entity == null)
            {
                //throw new EntityNotFoundException(typeof(TEntity), id);
            }
            return entity;
        }
        #endregion

        #region SaveChanges
        public virtual async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public virtual void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        #endregion
    }
}
