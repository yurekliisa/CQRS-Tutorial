using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Core.Repository
{
    public interface IRepositoryBase<TEntity,TKey>
    {
        #region Insert
        TEntity Insert(TEntity entity, bool autoSave = true);
        Task<TEntity> InsertAsync(TEntity entity, bool autoSave = true);
        #endregion

        #region Update
        TEntity Update(TEntity entity, bool autoSave = true);
        Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = true);
        #endregion

        #region Delete
        void Delete(TEntity entity, bool autoSave = true);
        Task DeleteAsync(TEntity entity, bool autoSave = true);
       
        #endregion

        #region GetList with includeDetails
        List<TEntity> GetList(bool includeDetails = false);
        Task<List<TEntity>> GetListAsync(bool includeDetails = false);
        #endregion


        #region GetQueryable
        IQueryable<TEntity> GetQueryable();
        #endregion

      
        #region Get
        TEntity Get(TKey id);
        Task<TEntity> GetAsync(TKey id);
        #endregion

      
        #region SaveChanges
        Task SaveChangesAsync();
        void SaveChanges();
        #endregion
    }
}
