using EShop.BL.DTOs;

namespace EShop.BL.Enums
{
    public class ProductCategoryDTO
    {
        public int ProductCategoryDTOId { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }

        public ProductDTO Product { get; set; }
    }
}