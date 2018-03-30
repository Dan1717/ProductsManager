using ProductsManager.DataAccess.Context;
using ProductsManager.DataAccess.Repository;
using ProductsManager.Models.DAO;
using System;

namespace ProductsManager.DataAccess.Unit
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _dbContext;

        private IGenericRepository<Category> _categoryRepo;
        private IGenericRepository<Product> _productRepo;

        public UnitOfWork(DataContext dataContext) {
	        _dbContext = dataContext;

            _categoryRepo = new GenericRepository<Category>(_dbContext);
            _productRepo = new GenericRepository<Product>(_dbContext);
        }

        public IGenericRepository<Category> CategoryRepo
        {
            get
            {
                if (_categoryRepo == null) _categoryRepo = new GenericRepository<Category>(_dbContext);
                return _categoryRepo;
            }
        }
        public IGenericRepository<Product> ProductRepo
        {
            get
            {
                if (_productRepo == null) _productRepo = new GenericRepository<Product>(_dbContext);
                return _productRepo;
            }
        }
        public int Save()
        {
                return _dbContext.SaveChanges();
        }

        #region Dispose

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
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
