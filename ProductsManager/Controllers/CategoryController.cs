using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProductsManager.Models.DTO.Category;
using ProductsManager.Services.Interfaces;

namespace ProductsManager.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _categoryManager;
        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        // GET: api/Category
        [HttpGet]
        public CategoryGet Get(int id)
        {
            return _categoryManager.Get(id);
        }


        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        public CategoryGetAll GetAll()
        {
            return _categoryManager.GetAll();
        }

        // POST: api/Category
        [HttpPost]
        public void Post([FromBody] CategoryCreate category)
        {
            _categoryManager.Create(category);
        }
        
        // PUT: api/Category/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]CategoryUpdate category)
        {
            _categoryManager.Update(category);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryManager.Delete(id);
        }
    }
}
