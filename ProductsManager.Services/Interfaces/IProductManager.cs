using ProductsManager.Models.DTO.Product;

namespace ProductsManager.Services.Interfaces
{
    public interface IProductManager
    {
        void Create(ProductsCreate categoryCreate);
        void Delete(int id);
        void Update(ProductUpdate category);
        ProductGet Get(int id);
        ProductGetAll GetAll();
    }
}
