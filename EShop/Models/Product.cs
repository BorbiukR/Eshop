using EShop.DAL.Enums;

namespace Eshop.DAL.Models
{
    public class Product
    {
        public int ProductId { get; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public ProductCategory ProductCategory { get; set; }
    }
}
