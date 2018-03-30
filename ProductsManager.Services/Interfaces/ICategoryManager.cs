using ProductsManager.Models.DTO.Category;

namespace ProductsManager.Services.Interfaces
{
    public interface ICategoryManager
    {
        void Create(CategoryCreate categoryCreate);
        void Delete(int id);
        ServiceResponse<CategoryUpdate> Update(int id, ServiceResponse<CategoryUpdate> category);
	    ServiceResponse<CategoryGet> Get(int id);
        CategoryGetAll GetAll();
    }
}
