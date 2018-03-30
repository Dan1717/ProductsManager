using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProductsManager.Models.DTO.Category;
using ProductsManager.Services;
using ProductsManager.Services.Interfaces;

namespace ProductsManager.WebApi.Controllers
{
	public static class ServiceResponseExtensions
	{
		public static JsonResult ToJsonResult<TResponse>(this ServiceResponse<TResponse> response) {
			JsonResult result;
			if (response.IsValid) {
				result = new JsonResult(response.Response);
			}
			else {
				result = new JsonResult(response.Errors);
			}

			result.StatusCode = response.ResultCode;
			return result;
		}
	}

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
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
		{
	        var categoryResponse = _categoryManager.Get(id);
			return categoryResponse.ToJsonResult();
		}

        // GET: api/Category/5
        [HttpGet]
        public IActionResult Get() {
	        var categoryResponse = _categoryManager.GetAll();

			return new ObjectResult(_categoryManager.GetAll());
        }

        // POST: api/Category
        [HttpPost]
        public IActionResult Post([FromBody] CategoryCreate category)
        {
	        if (category == null) {
		        return BadRequest();
	        }
            _categoryManager.Create(category);
	        return new ObjectResult(category);
		}
        
        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CategoryUpdate category) {
	        var responce = new ServiceResponse<CategoryUpdate> {Response = category};
	        var categoryResponse = _categoryManager.Update(id, responce);
			return categoryResponse.ToJsonResult();
		}
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryManager.Delete(id);
        }
    }
}
