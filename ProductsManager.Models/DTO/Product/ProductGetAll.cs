using System.Collections.Generic;

namespace ProductsManager.Models.DTO.Product
{
    public class ProductGetAll
    {
        IEnumerable<ProductGet> Products { get; set; }
    }
}
