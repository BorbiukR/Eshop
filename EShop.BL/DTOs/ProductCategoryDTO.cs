namespace EShop.BL.DTOs
{
    public class ProductCategoryDTO
    {
        public int Id { get; }
        public string Name { get; set; }
        public int ProductId { get; set; }

        public ProductDTO Product { get; set; }
    }
}