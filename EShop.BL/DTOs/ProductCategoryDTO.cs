namespace EShop.BL.DTOs
{
    public class ProductCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }

        public ProductDTO Product { get; set; }
    }
}