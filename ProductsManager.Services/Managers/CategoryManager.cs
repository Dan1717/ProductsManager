using AutoMapper;
using ProductsManager.DataAccess.Unit;
using ProductsManager.Models.DAO;
using ProductsManager.Models.DTO.Category;
using ProductsManager.Services.Interfaces;
using System;

namespace ProductsManager.Services.Managers
{
    
    public class CategoryManager : ICategoryManager
    {
        private IUnitOfWork _unitOfWork;
        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(CategoryCreate categoryCreate)
        {
            if(categoryCreate != null)
            {
                var category = Mapper.Map<Category>(categoryCreate);
                _unitOfWork.CategoryRepo.Add(category);
                _unitOfWork.Save();
            }
        }

        public void Delete(int id)
        {
            var category = _unitOfWork.CategoryRepo.GetById(id);
            if (category != null)
            {
                _unitOfWork.CategoryRepo.Delete(category);
            }
            _unitOfWork.Save();
        }

        public ServiceResponse<CategoryUpdate> Update (int id, ServiceResponse<CategoryUpdate> categoryUpdateRequest)
        {
	        var serviceResponse = new ServiceResponse<CategoryUpdate>();
	        if (categoryUpdateRequest == null || id != categoryUpdateRequest.Response.Id)
			{
				serviceResponse.Errors.Add(nameof(id), $"Category with id {id} does not exists or invalid id!");
				serviceResponse.ResultCode = 404;
			}
           
            if (serviceResponse.IsValid && categoryUpdateRequest != null)
			{
				var currentCategory = _unitOfWork.CategoryRepo.GetById(categoryUpdateRequest.Response.Id);
				if (currentCategory != null) {
					currentCategory = Mapper.Map<Category>(categoryUpdateRequest);
					_unitOfWork.CategoryRepo.Update(currentCategory);
				}
			}
			return serviceResponse;
        }

        public ServiceResponse<CategoryGet> Get (int id)
        {
            var category = _unitOfWork.CategoryRepo.GetById(id);

			var serviceResponse = new ServiceResponse<CategoryGet>();
	        if (category == null) {
		        serviceResponse.Errors.Add(nameof(id), $"Category with id {id} does not exists!");
		        serviceResponse.ResultCode = 404;
	        }

	        if (serviceResponse.IsValid) {
		        serviceResponse.Response = Mapper.Map<CategoryGet>(category);
	        }

	        return serviceResponse;
        }

        public CategoryGetAll GetAll()
        {
            var categories = _unitOfWork.CategoryRepo.GetAll;
            return Mapper.Map<CategoryGetAll>(categories);
        }
    }
}
