using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsManager.Models.DTO.Product;
using ProductsManager.Services.Interfaces;

namespace ProductsManager.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        // GET: api/Product
        [HttpGet]
        public ProductGet Get(int id)
        {
            return _productManager.Get(id);
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public ProductGetAll GetAll()
        {
            return _productManager.GetAll();
        }

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody]ProductsCreate product)
        {
            _productManager.Create(product);
        }
        
        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ProductUpdate product)
        {
            _productManager.Update(product);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productManager.Delete(id);
        }
    }
}
