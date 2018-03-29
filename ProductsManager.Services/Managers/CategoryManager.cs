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

        public void Update (CategoryUpdate category)
        {
            var currentCategory = _unitOfWork.CategoryRepo.GetById(category.Id);
            if (currentCategory != null)
            {
               currentCategory = Mapper.Map<Category>(category);
            }
        }

        public CategoryGet Get (int id)
        {
            var category = _unitOfWork.CategoryRepo.GetById(id);

            return category != null ? Mapper.Map<CategoryGet>(category) : null;
        }

        public CategoryGetAll GetAll()
        {
            var categories = _unitOfWork.CategoryRepo.GetAll;
            return Mapper.Map<CategoryGetAll>(categories);
        }
    }
}
