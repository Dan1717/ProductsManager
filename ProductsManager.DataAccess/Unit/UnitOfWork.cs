using ProductsManager.DataAccess.Context;
using ProductsManager.DataAccess.Repository;
using ProductsManager.Models.DAO;
using System;

namespace ProductsManager.DataAccess.Unit
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DataContext dbContext;

        private IGenericRepository<Category> _categoryRepo;
        private IGenericRepository<Product> _productRepo;

        public UnitOfWork()
        {
            dbContext = new DataContext();

            _categoryRepo = new GenericRepository<Category>(dbContext);
            _productRepo = new GenericRepository<Product>(dbContext);
        }

        public IGenericRepository<Category> CategoryRepo
        {
            get
            {
                if (_categoryRepo == null) _categoryRepo = new GenericRepository<Category>(dbContext);
                return _categoryRepo;
            }
        }
        public IGenericRepository<Product> ProductRepo
        {
            get
            {
                if (_productRepo == null) _productRepo = new GenericRepository<Product>(dbContext);
                return _productRepo;
            }
        }
        public void UpdateContext()
        {
            dbContext = new DataContext();
        }
        public int Save()
        {
            try
            {
                return dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #region Dispose

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Dispose
    }
}
