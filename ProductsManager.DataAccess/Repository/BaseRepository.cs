//using Microsoft.EntityFrameworkCore;
//using ProductsManager.DataAccess.Context;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

using Microsoft.EntityFrameworkCore;
using ProductsManager.DataAccess.Context;
using ProductsManager.DataAccess.Repository;
using System.Linq;

namespace ProductsManager.DataAccess
{
    public abstract class BaseRepository <TEntity> : IBaseRepository <TEntity> where TEntity : class
    {
        public DataContext dbcontext;
        public DbSet<TEntity> dbSet;

        public BaseRepository(DataContext context)
        {
            this.dbcontext = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual TEntity GetById(int entityId)
        {
            return dbcontext.Set<TEntity>().Find(entityId);
        }

        public virtual IQueryable<TEntity> GetAll
        {
            get
            {
                return dbSet;
            }
        }

        public virtual TEntity Add(TEntity entity)
        {
            return dbSet.Add(entity).Entity;
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (dbcontext.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            dbcontext.Entry(entityToUpdate).State = EntityState.Modified;
        }

    }
}
