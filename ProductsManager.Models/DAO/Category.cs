using System.ComponentModel.DataAnnotations;

namespace ProductsManager.Models.DAO
{
    public class Category
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
