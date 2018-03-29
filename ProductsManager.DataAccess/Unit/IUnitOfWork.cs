using ProductsManager.DataAccess.Repository;
using ProductsManager.Models.DAO;

namespace ProductsManager.DataAccess.Unit
{
    public interface IUnitOfWork
    {
        IGenericRepository<Category> CategoryRepo { get; }
        IGenericRepository<Product> ProductRepo { get; }

        void Dispose();

        int Save();
    }
}
