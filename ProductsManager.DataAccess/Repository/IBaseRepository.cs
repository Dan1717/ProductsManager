using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductsManager.DataAccess.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int entityId);
        IQueryable<TEntity> GetAll { get; }
        TEntity Add(TEntity entity);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }
}
