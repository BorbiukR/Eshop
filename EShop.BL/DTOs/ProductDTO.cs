namespace EShop.BL.DTOs
{
    public class ProductDTO
    {
        public int Id { get; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public ProductCategoryDTO Category { get; set; }
    }
}