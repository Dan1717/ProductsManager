using AutoMapper;
using ProductsManager.DataAccess.Unit;
using ProductsManager.Models.DAO;
using ProductsManager.Models.DTO.Product;
using ProductsManager.Services.Interfaces;

namespace ProductsManager.Services.Managers
{
    public class ProductManager : IProductManager
    {
        private IUnitOfWork _unitOfWork;
        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(ProductsCreate productCreate)
        {
            if (productCreate != null)
            {
                var product = Mapper.Map<Product>(productCreate);
                _unitOfWork.ProductRepo.Add(product);
                _unitOfWork.Save();
            }
        }

        public void Delete(int id)
        {
            var product = _unitOfWork.ProductRepo.GetById(id);
            if (product != null)
            {
                _unitOfWork.ProductRepo.Delete(product);
            }
            _unitOfWork.Save();
        }

        public void Update(ProductUpdate product)
        {
            var currentProduct = _unitOfWork.ProductRepo.GetById(product.Id);
            if (currentProduct != null)
            {
                currentProduct = Mapper.Map<Product>(product);
            }
        }

        public ProductGet Get(int id)
        {
            var product = _unitOfWork.ProductRepo.GetById(id);

            return product != null ? Mapper.Map<ProductGet>(product) : null;
        }

        public ProductGetAll GetAll()
        {
            var product = _unitOfWork.ProductRepo.GetAll;
            return Mapper.Map<ProductGetAll>(product);
        }
    }
}
