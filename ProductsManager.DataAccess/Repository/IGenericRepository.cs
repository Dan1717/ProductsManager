using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsManager.DataAccess.Repository
{
    public interface IGenericRepository<TEntity> : IBaseRepository<TEntity>
     where TEntity : class
    {
    }
}
