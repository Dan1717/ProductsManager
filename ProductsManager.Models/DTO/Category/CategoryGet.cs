namespace ProductsManager.Models.DTO.Category
{
    public class ProductGet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
