using AutoMapper;
using ProductsManager.Models.DAO;
using ProductsManager.Models.DTO.Category;
using ProductsManager.Models.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductsManager.Services.Mapping
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<CategoryCreate, Category>()
                .ForMember(m => m.Name, n => n.MapFrom(s => s.Name))
                .ForMember(m => m.ParentCategoryId, n => n.MapFrom(s => s.ParentCategoryId));
            CreateMap<CategoryUpdate, Category>()
                .ForMember(m => m.Id, n => n.MapFrom(s => s.Id))
                .ForMember(m => m.Name, n => n.MapFrom(s => s.Name))
                .ForMember(m => m.ParentCategoryId, n => n.MapFrom(s => s.ParentCategoryId));
            CreateMap<IQueryable<Category>, CategoryGetAll>()
                .ConvertUsing(MapCategoryAll);
            CreateMap<CategoryGet, Category>()
                .ForMember(m => m.Id, n => n.MapFrom(s => s.Id))
                .ForMember(m => m.Name, n => n.MapFrom(s => s.Name))
                .ForMember(m => m.ParentCategoryId, n => n.MapFrom(s => s.ParentCategoryId));


            CreateMap<ProductsCreate, Product>()
                .ForMember(m => m.Name, n => n.MapFrom( s => s.Name))
                .ForMember(m => m.CategoryId, n => n.MapFrom( s => s.CategoryId));
            CreateMap<ProductUpdate, Product>()
                .ForMember(m => m.Id, n => n.MapFrom(s => s.Id))
                .ForMember(m => m.Name, n => n.MapFrom(s => s.Name))
                .ForMember(m => m.CategoryId, n => n.MapFrom(s => s.CategoryId));
            CreateMap<IQueryable<Product>, ProductGetAll>()
                .ConvertUsing(MapProductAll);

            CreateMap<ProductGet, Product>()
                .ForMember(m => m.Id, n => n.MapFrom(s => s.Id))
                .ForMember(m => m.Name, n => n.MapFrom(s => s.Name))
                .ForMember(m => m.CategoryId, n => n.MapFrom(s => s.CategoryId));
        }

        private ProductGetAll MapProductAll (IQueryable<Product> products)
        {
            return new ProductGetAll()
            {
                Products = products.Select(Mapper.Map<ProductGet>)
            };
        }
        private CategoryGetAll MapCategoryAll (IQueryable<Category> categories)
        {
            return new CategoryGetAll()
            {
                Categories = categories.Select(Mapper.Map<CategoryGet>)
            };
        }
    }
}
