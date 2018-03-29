using ProductsManager.Models.DTO.Category;

namespace ProductsManager.Services.Interfaces
{
    public interface ICategoryManager
    {
        void Create(CategoryCreate categoryCreate);
        void Delete(int id);
        void Update(CategoryUpdate category);
        CategoryGet Get(int id);
        CategoryGetAll GetAll();
    }
}
