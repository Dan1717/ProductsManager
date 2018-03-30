using ProductsManager.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsManager.DataAccess.Repository
{
    public class GenericRepository<TEntity> : BaseRepository<TEntity>,
        IGenericRepository<TEntity> where TEntity : class
    {
        public GenericRepository(DataContext unitOfWork)
          : base(unitOfWork)
        {
        }
    }
}
